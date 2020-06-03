using System;
using TextEditor.BL;

namespace TextEditor
{
    class MainPresenter
    {

        private readonly iMainForm _view;
        private readonly iFileManager _manager;
        private readonly iMessageService _messageService;
        private string _currentFilePatch;

        public MainPresenter(iMainForm view, iFileManager manager, iMessageService messageService)
        {
            _view = view;
            _manager = manager;
            _messageService = messageService;

            _view.SetSymbolCount(0);
            _view.ContentChanged += new EventHandler(_view_ContentChanged);
            _view.FileOpenClick += new EventHandler(_view_FileOpenClick);
            _view.FileSaveClick += new EventHandler(_view_FileSaveClick);

        }

        private void _view_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string content = _view.Content;
                _manager.SaveContent (_currentFilePatch, content);
                _messageService.ShowMessage("Файл успешно сохранен!");
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }


        }

        private void _view_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filepatch = _view.FilePatch;
                bool isExcist = _manager.FileExist(filepatch);

                if (!isExcist)
                {
                    _messageService.ShowExclamation("Выбранный файл не существует");
                    return;
                }
                _currentFilePatch = filepatch;

                string content = _manager.GetContent(filepatch);
                int count = _manager.GetSymbolCount(content);

                _view.Content = content;
                _view.SetSymbolCount( count);

            }
            catch(Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        void _view_ContentChanged(object sender, EventArgs e)
        {
            string content = _view.Content;
            int count = _manager.GetSymbolCount(content);
            _view.SetSymbolCount(count);

        }
    }
}
