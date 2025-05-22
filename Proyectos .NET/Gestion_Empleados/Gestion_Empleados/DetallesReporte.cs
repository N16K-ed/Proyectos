using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Gestion_Empleados
{
    public partial class DetallesReporte : Form
    {
        private int reporteId;
        private string asunto;
        private string descripcion;
        private bool urgente;
        private DateTime fechaReporte;

        public DetallesReporte(int id)
        {
            InitializeComponent();
            reporteId = id;
            this.Load += DetallesReporte_Load;
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
            button2.Click += Button2_Click; 
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void DetallesReporte_Load(object sender, EventArgs e)
        {
            CargarReporte(reporteId);
        }

        private void CargarReporte(int id)
        {
            string connectionString = "Server=PMPW1364\\SQLEXPRESS;Database=bdGestionEmpleados;Trusted_Connection=True;";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Asunto, Descripcion, Urgente, FechaReporte FROM Reportes WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                asunto = reader.GetString(0);
                                descripcion = reader.GetString(1);
                                urgente = reader.GetBoolean(2);
                                fechaReporte = reader.GetDateTime(3);

                                textBox1.Text = asunto;
                                textBox4.Text = descripcion;
                                textBox3.Text = urgente ? "✓" : "X";
                            }
                            else
                            {
                                MessageBox.Show("Reporte no encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                Title = "Guardar Reporte como PDF",
                FileName = $"Reporte_{reporteId}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 40, 40, 40, 40);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        writer.PageEvent = new PdfPageNumberFooter();
                        pdfDoc.Open();

                        // Imagen del encabezado
                        string imagePath = Path.Combine(Application.StartupPath, "Datos", "logo.png");
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imagePath);
                        float pageWidth = pdfDoc.PageSize.Width;
                        float usableWidth = pageWidth - pdfDoc.LeftMargin - pdfDoc.RightMargin;
                        logo.ScaleToFit(usableWidth, pdfDoc.PageSize.Height);
                        logo.Alignment = Element.ALIGN_CENTER;
                        logo.SpacingAfter = 20f;
                        pdfDoc.Add(logo);

                        // Fuentes
                        var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                        var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                        var bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);

                        // Título
                        Paragraph title = new Paragraph("Reporte de Empleado", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 20f
                        };
                        pdfDoc.Add(title);

                        // Tabla de datos
                        PdfPTable table = new PdfPTable(2)
                        {
                            WidthPercentage = 100
                        };
                        table.SetWidths(new float[] { 1f, 3f });

                        // Función para crear celda de encabezado
                        PdfPCell AddHeader(string texto)
                        {
                            return new PdfPCell(new Phrase(texto, headerFont))
                            {
                                BackgroundColor = BaseColor.DARK_GRAY,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5,
                                BorderColor = BaseColor.LIGHT_GRAY
                            };
                        }

                        // Función para crear celda de valor
                        PdfPCell AddValue(string texto)
                        {
                            return new PdfPCell(new Phrase(texto, bodyFont))
                            {
                                Padding = 5,
                                BorderColor = BaseColor.LIGHT_GRAY
                            };
                        }

                        table.AddCell(AddHeader("ID"));
                        table.AddCell(AddValue(reporteId.ToString()));

                        table.AddCell(AddHeader("Asunto"));
                        table.AddCell(AddValue(asunto));

                        table.AddCell(AddHeader("Urgente"));
                        table.AddCell(AddValue(urgente ? "✓" : "X"));

                        table.AddCell(AddHeader("Fecha"));
                        table.AddCell(AddValue(fechaReporte.ToString("dd/MM/yyyy")));

                        pdfDoc.Add(table);

                        // Descripción fuera de la tabla
                        Paragraph descLabel = new Paragraph("Descripción del Reporte:", headerFont)
                        {
                            SpacingBefore = 20f,
                            SpacingAfter = 10f
                        };
                        pdfDoc.Add(descLabel);

                        PdfPCell descripcionCell = new PdfPCell(new Phrase(descripcion, bodyFont))
                        {
                            Border = iTextSharp.text.Rectangle.BOX,
                            BorderColor = BaseColor.LIGHT_GRAY,
                            Padding = 10,
                            MinimumHeight = 300,
                            UseAscender = true
                        };

                        PdfPTable descTable = new PdfPTable(1)
                        {
                            WidthPercentage = 100
                        };
                        descTable.AddCell(descripcionCell);
                        pdfDoc.Add(descTable);

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("PDF generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            VerReportes verReportes = new VerReportes()
            {
                Visible = true
            };
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDashboard formDashboard = new FormDashboard()
            {
                Visible = true
            };
            Visible = false;
        }
    }

    public class PdfPageNumberFooter : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            PdfContentByte cb = writer.DirectContent;
            cb.BeginText();

            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bf, 10);

            float x = (document.Right + document.Left) / 2;
            float y = document.Bottom - 20;

            cb.ShowTextAligned(Element.ALIGN_CENTER, $"Página {writer.PageNumber}", x, y, 0);

            cb.EndText();
        }
    }
}
