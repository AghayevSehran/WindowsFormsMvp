using Mvp.PresentationLayer;
using System;
using System.Windows.Forms;

namespace WindowsFormsMvp
{
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

        public event EventHandler<EventArgs> Save;

        private void button1_Click(object sender, EventArgs e)
        {
            Save?.Invoke(this, EventArgs.Empty);
        }
    }
}
