using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

namespace AutoLock
{
    public partial class Main : Form
    {
        // Variables for face recording
        private VideoCapture _capture;
        private CascadeClassifier _faceCascade;
        private bool _isRecording = false;
        private bool _isMonitoring = false;

        // Directory to save face data
        private readonly string _faceDataDir = Path.Combine(Environment.CurrentDirectory, "FaceData");

        // Face recognizer
        private EigenFaceRecognizer _recognizer;

        // For locking the workstation
        [DllImport("user32.dll")]
        private static extern void LockWorkStation();

        // Counters for face image recording
        private int _faceImageCount = 0;
        private int _maxFaceImages = 500; // Adjust this number as needed

        public Main()
        {
            InitializeComponent();
            InitializeFaceDetection();
            InitializeRecognizer();
        }

        private void InitializeFaceDetection()
        {
            // Ensure the Haar Cascade file is in the executable directory
            string faceCascadePath = @"haarcascade_frontalface_default.xml";
            if (!File.Exists(faceCascadePath))
            {
                MessageBox.Show("Haar Cascade file not found!");
                Application.Exit();
            }

            _faceCascade = new CascadeClassifier(faceCascadePath);
        }

        private void InitializeRecognizer()
        {
            if (Directory.Exists(_faceDataDir))
            {
                TrainRecognizer();
            }
        }

        private void btnRecordStart_Click(object sender, EventArgs e)
        {
            if (!_isRecording)
            {
                _faceImageCount = 0; // Reset the counter
                _isRecording = true;
                _capture = new VideoCapture();
                if (!_capture.IsOpened)
                {
                    MessageBox.Show("Failed to open video capture device.");
                    return;
                }
                Application.Idle += ProcessFrameAndSaveFace;
                lblStatus.Text = "Recording face data...";
            }
        }

        private void ProcessFrameAndSaveFace(object sender, EventArgs e)
        {
            try
            {
                if (_capture != null)
                {
                    using (Mat frame = _capture.QueryFrame())
                    {
                        if (frame != null)
                        {
                            Mat grayFrame = new Mat();
                            CvInvoke.CvtColor(frame, grayFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                            var faces = _faceCascade.DetectMultiScale(
                                grayFrame,
                                scaleFactor: 1.1,
                                minNeighbors: 5,
                                minSize: new Size(50, 50)
                            );

                            if (faces.Length == 0)
                            {
                                lblStatus.Text = "No face detected.";
                            }
                            else
                            {
                                foreach (var face in faces)
                                {
                                    // Draw rectangle around the face
                                    CvInvoke.Rectangle(frame, face, new MCvScalar(0, 0, 255), 2);

                                    // Extract the face ROI and resize
                                    Mat faceImage = new Mat(grayFrame, face);
                                    CvInvoke.Resize(faceImage, faceImage, new Size(100, 100));

                                    SaveFaceData(faceImage);
                                }
                            }

                            // Display the frame
                            pictureBox1.Image = frame.ToImage<Bgr, byte>().ToBitmap();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during face recording: {ex.Message}");
                StopRecording();
            }
        }

        private void SaveFaceData(Mat faceImage)
        {
            if (!Directory.Exists(_faceDataDir))
                Directory.CreateDirectory(_faceDataDir);

            string filePath = Path.Combine(_faceDataDir, $"{Guid.NewGuid()}.png");
            CvInvoke.Imwrite(filePath, faceImage);

            _faceImageCount++;

            // Update the status label
            lblStatus.Text = $"Saved {_faceImageCount}/{_maxFaceImages} face images.";

            // Check if the maximum number of images has been reached
            if (_faceImageCount >= _maxFaceImages)
            {
                // Stop recording
                StopRecording();

                // Notify the user
                MessageBox.Show("Face data recording completed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StopRecording()
        {
            if (_isRecording)
            {
                Application.Idle -= ProcessFrameAndSaveFace;
                _capture?.Dispose();
                _capture = null;
                _isRecording = false;
                lblStatus.Text = "Face recording stopped.";
                _faceImageCount = 0; // Reset the counter

                // Train the recognizer after recording is stopped
                TrainRecognizer();
            }
        }


        private void TrainRecognizer()
        {
            var faceMats = new List<Mat>();
            var labels = new List<int>();

            var files = Directory.GetFiles(_faceDataDir, "*.png");
            int label = 0;

            foreach (var file in files)
            {
                // Read the image as a Mat
                Mat img = CvInvoke.Imread(file, Emgu.CV.CvEnum.ImreadModes.Grayscale);
                faceMats.Add(img);
                labels.Add(label);
            }

            if (faceMats.Count > 0)
            {
                _recognizer = new EigenFaceRecognizer();
                _recognizer.Train(faceMats.ToArray(), labels.ToArray());
                lblStatus.Text = "Face recognizer trained.";
            }
            else
            {
                lblStatus.Text = "No face data available for training.";
            }
        }

        private void btnAutoLockStart_Click(object sender, EventArgs e)
        {
            if (!_isMonitoring)
            {
                if (_recognizer == null)
                {
                    MessageBox.Show("Please record your face data before starting auto-lock.");
                    return;
                }

                _isMonitoring = true;
                _capture = new VideoCapture();
                if (!_capture.IsOpened)
                {
                    MessageBox.Show("Failed to open video capture device.");
                    return;
                }
                Application.Idle += MonitorFace;
                lblStatus.Text = "Auto-lock enabled. Monitoring...";
            }
        }

        private void MonitorFace(object sender, EventArgs e)
        {
            try
            {
                if (_capture != null)
                {
                    using (Mat frame = _capture.QueryFrame())
                    {
                        if (frame != null)
                        {
                            Mat grayFrame = new Mat();
                            CvInvoke.CvtColor(frame, grayFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                            var faces = _faceCascade.DetectMultiScale(
                                grayFrame,
                                scaleFactor: 1.1,
                                minNeighbors: 5,
                                minSize: new Size(50, 50)
                            );

                            if (faces.Length == 0)
                            {
                                lblStatus.Text = "No face detected.";
                            }
                            else
                            {
                                foreach (var face in faces)
                                {
                                    Mat faceImage = new Mat(grayFrame, face);
                                    CvInvoke.Resize(faceImage, faceImage, new Size(100, 100));

                                    var result = _recognizer.Predict(faceImage);

                                    // Add debugging information
                                    lblStatus.Text = $"Label: {result.Label}, Distance: {result.Distance}";

                                    // Adjust the threshold as needed
                                    if (result.Label != 0 || result.Distance > 5000)
                                    {
                                        // Unrecognized face detected
                                        LockWorkStation();
                                        StopMonitoring();
                                        lblStatus.Text = "Unrecognized face detected. Computer locked.";
                                        break;
                                    }
                                    else
                                    {
                                        // Recognized face
                                        lblStatus.Text = "Face recognized. Monitoring...";
                                    }
                                }
                            }

                            // Display the frame
                            pictureBox1.Image = frame.ToImage<Bgr, byte>().ToBitmap();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during monitoring: {ex.Message}");
                StopMonitoring();
            }
        }

        private void StopMonitoring()
        {
            if (_isMonitoring)
            {
                Application.Idle -= MonitorFace;
                _capture?.Dispose();
                _capture = null;
                _isMonitoring = false;
                lblStatus.Text = "Auto-lock disabled.";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopRecording();
            StopMonitoring();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopMonitoring();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopRecording();
            StopMonitoring();
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopRecording();
            StopMonitoring();
        }
    }
}
