using SkiaSharp;
using ViewFaceCore.Configs;
using ViewFaceCore.Core;
using ViewFaceCore.Model;
using ViewFaceCore;

namespace TestFaceMask
{
    public partial class frmMain : Form
    {
        private class ImageFaceInfo
        {
            public FaceInfo Face;
            public FaceMarkPoint[] MarkPoints;
            public bool IsSamePerson = false;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private Image m_image;
        private const int m_startX = 50;
        private const int m_startY = 50;
        private float m_scale = 1;
        private Point m_startPoint;
        private Bitmap m_selectImage;
        private List<ImageFaceInfo> m_faces = new List<ImageFaceInfo>();

        private void pnlImage_Paint(object sender, PaintEventArgs e)
        {
            if (m_image != null)
            {
                e.Graphics.ResetTransform();
                e.Graphics.PageUnit = GraphicsUnit.Pixel;
                e.Graphics.TranslateTransform(pnlImage.AutoScrollPosition.X, pnlImage.AutoScrollPosition.Y);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                e.Graphics.DrawImage(m_image, m_startX, m_startY, m_image.Width * m_scale, m_image.Height * m_scale);

                if (m_faces.Count > 0)
                {
                    for (int i = 0; i < m_faces.Count; i++)
                    {
                        e.Graphics.DrawRectangle(m_faces[i].IsSamePerson ? Pens.Blue : Pens.Red,
                            m_startX + m_faces[i].Face.Location.X * m_scale,
                            m_startY + m_faces[i].Face.Location.Y * m_scale,
                            m_faces[i].Face.Location.Width * m_scale,
                            m_faces[i].Face.Location.Height * m_scale);

                        e.Graphics.DrawString(Convert.ToString(i + 1), this.Font, Brushes.Red,
                                new PointF(m_startX + m_faces[i].Face.Location.X * m_scale, m_startY + m_faces[i].Face.Location.Y * m_scale - this.Font.Height * 1.5f));
                        
                        if (!cbMask.Checked)
                        {
                            if (m_faces[i].MarkPoints != null && m_faces[i].MarkPoints.Length > 0)
                            {
                                foreach (FaceMarkPoint mp in m_faces[i].MarkPoints)
                                {
                                    e.Graphics.DrawEllipse(m_faces[i].IsSamePerson ? Pens.Blue : Pens.Red, m_startX + Convert.ToInt32(mp.X - 3) * m_scale, m_startY + Convert.ToInt32(mp.Y - 3) * m_scale, 6 * m_scale, 6 * m_scale);
                                }
                            }
                        }
                    }

                    if (cbMask.Checked)
                    {
                        if (rbColor.Checked)
                        {
                            using (SolidBrush sb = new SolidBrush(btnSelectColor.BackColor))
                            {
                                for (int i = 0; i < m_faces.Count; i++)
                                {

                                    e.Graphics.FillRectangle(sb,
                                        m_startX + m_faces[i].Face.Location.X * m_scale,
                                        m_startY + m_faces[i].Face.Location.Y * m_scale,
                                        m_faces[i].Face.Location.Width * m_scale,
                                        m_faces[i].Face.Location.Height * m_scale);
                                }
                            }
                        }

                        if (rbImage.Checked && picMaskImage.Image != null)
                        {
                            for (int i = 0; i < m_faces.Count; i++)
                            {

                                e.Graphics.DrawImage(picMaskImage.Image,
                                    m_startX + m_faces[i].Face.Location.X * m_scale,
                                    m_startY + m_faces[i].Face.Location.Y * m_scale,
                                    m_faces[i].Face.Location.Width * m_scale,
                                    m_faces[i].Face.Location.Height * m_scale);
                            }
                        }
                    }
                }
            }
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            m_image = Image.FromFile(ofd.FileName);
            pnlImage.Tag = ofd.FileName;

            UpdateScrollSize();
            m_faces.Clear();
            pnlImage.Refresh();
        }

        private void UpdateScrollSize()
        {
            if (m_image != null)
            {
                pnlImage.AutoScrollMinSize = new Size(Convert.ToInt32(m_startX * 2 + m_image.Width * m_scale), Convert.ToInt32(m_startY * 2 + m_image.Height * m_scale));
            }
        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            m_scale = Convert.ToSingle(nudScale.Value / 100);
            UpdateScrollSize();
            pnlImage.Refresh();
        }

        private void btnFace_Click(object sender, EventArgs e)
        {
            var bitmap = SKBitmap.Decode(pnlImage.Tag.ToString());
            FaceDetector faceDetector = new FaceDetector();

            FaceLandmarkConfig config = new FaceLandmarkConfig();
            config.MarkType = MarkType.Normal;

            FaceLandmarker faceMark = new FaceLandmarker(config);

            m_faces.Clear();
            FaceInfo[] infos = faceDetector.Detect(bitmap);

            for (int i = 0; i < infos.Length; i++)
            {
                ImageFaceInfo fInfo = new ImageFaceInfo();
                fInfo.Face = infos[i];
                fInfo.MarkPoints = faceMark.Mark(bitmap, infos[i]);

                m_faces.Add(fInfo);
            }

            pnlImage.Refresh();

            faceDetector.Dispose();
            faceMark.Dispose();
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btnSelectColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnSelectColor.BackColor = cd.Color;

                pnlImage.Refresh();
            }
        }

        private void cbMask_CheckedChanged(object sender, EventArgs e)
        {
            pnlImage.Refresh();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            picMaskImage.Image = Image.FromFile(ofd.FileName);
            picMaskImage.Tag = ofd.FileName;

            pnlImage.Refresh();
        }

        ///   <summary> 
        ///  马赛克处理，参考自https://blog.csdn.net/yinsefeixingchuan/article/details/123435426
        ///   </summary> 
        ///   <param name="bitmap"></param> 
        ///   <param name="effectWidth">  影响范围 每一个格子数  </param> 
        ///   <returns></returns> 
        public Bitmap AdjustTobMosaic(System.Drawing.Bitmap bitmap, int effectWidth, int startX, int startY, int width, int height)
        {
            for (int heightOfffset = startY; heightOfffset < startY + height; heightOfffset += effectWidth)
            {
                for (int widthOffset = startX; widthOffset < startX + width; widthOffset += effectWidth)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    for (int x = widthOffset; (x < widthOffset + effectWidth && x < bitmap.Width); x++)
                    {
                        for (int y = heightOfffset; (y < heightOfffset + effectWidth && y < bitmap.Height); y++)
                        {
                            System.Drawing.Color pixel = bitmap.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    //  计算范围平均 
                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;


                    //  所有范围内都设定此值 
                    for (int x = widthOffset; (x < widthOffset + effectWidth && x < bitmap.Width); x++)
                    {
                        for (int y = heightOfffset; (y < heightOfffset + effectWidth && y < bitmap.Height); y++)
                        {

                            System.Drawing.Color newColor = System.Drawing.Color.FromArgb(avgR, avgG, avgB);
                            bitmap.SetPixel(x, y, newColor);
                        }
                    }
                }
            }
            return bitmap;
        }

        private void rbMsk_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMsk.Checked)
            {
                for (int i = 0; i < m_faces.Count; i++)
                {
                    m_image = AdjustTobMosaic(m_image as Bitmap, 20,
                        m_faces[i].Face.Location.X, m_faces[i].Face.Location.Y,
                        m_faces[i].Face.Location.Width, m_faces[i].Face.Location.Height);
                }

                pnlImage.Refresh();
            }
        }
    }
}