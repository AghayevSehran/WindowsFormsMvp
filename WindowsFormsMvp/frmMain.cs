using Mvp.PresentationLayer;
using System;
using System.Windows.Forms;

namespace WindowsFormsMvp
{
    //http://polymorphicpodcast.com/podcast/video/mv-patterns/usermessages/
    //http://polymorphicpodcast.com/shows/mv-patterns/
    public partial class frmMain : Form, IProductEditorView
    {
        private ProductEditorPresenter presenter;
        public frmMain()
        {
            InitializeComponent();
            presenter = new ProductEditorPresenter(this);
        }

        public int ProductId => Convert.ToInt32(txtId.Text);

        public string ProductDescription => txtName.Text;

        public bool IsProductSaved
        {
            set
            {
                if (value)
                {
                    panel1.Visible = !value;
                    panel2.Visible = value;
                }

            }

        }

        public event EventHandler<EventArgs> Save;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Save?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {

                PublishException(ex, "Error");
            }

        }

        public void PublishException(Exception ex, string frendlyName)
        {
            panel2.Visible = true;
            label3.Text = frendlyName;
        }
    }
}
