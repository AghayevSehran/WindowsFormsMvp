using Mvp.BusinessLayer;
using System;

namespace Mvp.PresentationLayer
{

    public interface IProductEditorView
    {
        int ProductId { get; }
        string ProductDescription { get; }
        bool IsProductSaved { set; }
        event EventHandler<EventArgs> Save;

    }

    public class ProductEditorPresenter
    {
        private IProductEditorView mView;

        public ProductEditorPresenter(IProductEditorView view)
        {
            mView = view;
            Initialize();
        }

        private void Initialize()
        {

            mView.Save += new EventHandler<EventArgs>(mView_Save);

        }


        private void mView_Save(object sender, EventArgs e)
        {
            Product product;
            try
            {
                product = new Product();
                product.Id = mView.ProductId;
                product.Description = mView.ProductDescription;
                product.Save();
                mView.IsProductSaved = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }


    }


}
