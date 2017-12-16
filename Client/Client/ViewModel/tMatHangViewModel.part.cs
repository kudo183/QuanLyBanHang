using Client.DataModel;
using huypq.SmtShared.Constant;
using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.ViewModel
{
    public partial class tMatHangViewModel : BaseViewModel<tMatHangDto, tMatHangDataModel>
    {
        const string ImageFileController = "SmtImageFile";

        partial void AfterLoadPartial()
        {
            foreach (var item in Entities)
            {
                if (item.MaHinhAnh != 0)
                {
                    item.HinhAnhImageStream = DataService.GetFileByID(item.MaHinhAnh, ImageFileController, ControllerAction.SmtImageFileBase.GetThumbnailByID);
                }
            }
        }

        protected override void BeforeSave()
        {
            foreach (var item in Entities)
            {
                if (item.MaHinhAnh == 0)
                {
                    if (string.IsNullOrEmpty(item.HinhAnhFilePath) == false)
                    {
                        //proccess Add
                        if (int.TryParse(DataService.AddFile(item.HinhAnhFilePath, ImageFileController), out int id) == true)
                        {
                            item.MaHinhAnh = id;
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(item.HinhAnhFilePath) == true)
                    {
                        if (item.HinhAnhImageStream == null)
                        {
                            //proccess Delete
                            DataService.DeteleFile(item.MaHinhAnh, ImageFileController);
                            item.MaHinhAnh = 0;
                        }
                    }
                    else
                    {
                        //proccess Update
                        DataService.UpdateFile(item.MaHinhAnh, item.HinhAnhFilePath, ImageFileController);
                    }
                }
            }
        }
    }
}
