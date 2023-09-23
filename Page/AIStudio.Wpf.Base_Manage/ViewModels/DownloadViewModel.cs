using AIStudio.Wpf.Business;
using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using Downloader;
using MahApps.Metro.Controls;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class DownloadViewModel : DockWindowViewModel
    {
        private readonly IDataProvider _dataProvider;
        private List<DownloadItem> DownloadList;
        //private  ProgressBar ConsoleProgress;
        private ConcurrentDictionary<string, ChildProgressBar> ChildConsoleProgresses = new ConcurrentDictionary<string, ChildProgressBar>();
        //private  ProgressBarOptions ChildOption;
        //private  ProgressBarOptions ProcessBarOption;
        private DownloadService CurrentDownloadService;
        private DownloadConfiguration CurrentDownloadConfiguration;
        private CancellationTokenSource CancelAllTokenSource;

        private long _maximumBytesPerSecond = 1024 * 1024 * 10;
        public long MaximumBytesPerSecond
        {
            get { return _maximumBytesPerSecond; }
            set
            {
                if (SetProperty(ref _maximumBytesPerSecond, value))
                {
                    CurrentDownloadConfiguration.MaximumBytesPerSecond = MaximumBytesPerSecond;
                }
            }
        }

        private double _progress;//Max 10000
        public double Progress
        {
            get { return _progress; }
            set
            {
                SetProperty(ref _progress, value);
            }
        }

        private ObservableCollection<ChildProgressBar> _childProgresses = new ObservableCollection<ChildProgressBar>();
        public ObservableCollection<ChildProgressBar> ChildProgresses
        {
            get { return _childProgresses; }
            set
            {
                SetProperty(ref _childProgresses, value);
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return this._startCommand ?? (this._startCommand = new DelegateCommand(() => this.Start()));
            }
        }

        private ICommand _pauseCommand;
        public ICommand PauseCommand
        {
            get
            {
                return this._pauseCommand ?? (this._pauseCommand = new DelegateCommand(() => this.Pause()));
            }
        }

        private ICommand _resumeCommand;
        public ICommand ResumeCommand
        {
            get
            {
                return this._resumeCommand ?? (this._resumeCommand = new DelegateCommand(() => this.Resume()));
            }
        }

        private ICommand _escapeCommand;
        public ICommand EscapeCommand
        {
            get
            {
                return this._escapeCommand ?? (this._escapeCommand = new DelegateCommand(() => this.Escape()));
            }
        }

        public DownloadViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            CancelAllTokenSource = new CancellationTokenSource();
            DownloadList = GetDownloadItems();
        }

        private async void Start()
        {
            await DownloadAll(DownloadList, CancelAllTokenSource.Token).ConfigureAwait(false);
        }

        private void Pause()
        {
            CurrentDownloadService?.Pause();
        }

        private void Resume()
        {
            CurrentDownloadService?.Resume();
        }

        private void Escape()
        {
            //CancelAllTokenSource.Cancel();
            CurrentDownloadService?.CancelAsync();
        }

        private DownloadConfiguration GetDownloadConfiguration()
        {
            var cookies = new System.Net.CookieContainer();
            cookies.Add(new System.Net.Cookie("download-type", "test") { Domain = "domain.com" });

            return new DownloadConfiguration
            {
                BufferBlockSize = 10240,    // usually, hosts support max to 8000 bytes, default values is 8000
                ChunkCount = 8,             // file parts to download, default value is 1
                MaximumBytesPerSecond = 1024 * 1024 * 10, // download speed limited to 10MB/s, default values is zero or unlimited
                MaxTryAgainOnFailover = 5,  // the maximum number of times to fail
                MaximumMemoryBufferBytes = 1024 * 1024 * 50, // release memory buffer after each 50 MB
                ParallelDownload = true,    // download parts of file as parallel or not. Default value is false
                ParallelCount = 4,          // number of parallel downloads. The default value is the same as the chunk count
                Timeout = 3000,             // timeout (millisecond) per stream block reader, default value is 1000
                RangeDownload = false,      // set true if you want to download just a specific range of bytes of a large file
                RangeLow = 0,               // floor offset of download range of a large file
                RangeHigh = 0,              // ceiling offset of download range of a large file
                ClearPackageOnCompletionWithFailure = true, // Clear package and downloaded data when download completed with failure, default value is false
                MinimumSizeOfChunking = 1024, // minimum size of chunking to download a file in multiple parts, default value is 512                                              
                ReserveStorageSpaceBeforeStartingDownload = true, // Before starting the download, reserve the storage space of the file as file size, default value is false
                RequestConfiguration =
                {
                    // config and customize request headers
                    Accept = "*/*",
                    CookieContainer = cookies,
                    Headers = new System.Net.WebHeaderCollection(),     // { your custom headers }
                    KeepAlive = true,                        // default value is false
                    ProtocolVersion = System.Net.HttpVersion.Version11, // default value is HTTP 1.1
                    UseDefaultCredentials = false,
                    // your custom user agent or your_app_name/app_version.
                    UserAgent = $"DownloaderSample/{Assembly.GetExecutingAssembly().GetName().Version?.ToString(3)}"
                    // Proxy = new WebProxy() {
                    //    Address = new Uri("http://YourProxyServer/proxy.pac"),
                    //    UseDefaultCredentials = false,
                    //    Credentials = System.Net.CredentialCache.DefaultNetworkCredentials,
                    //    BypassProxyOnLocal = true
                    // }
                }
            };
        }
        private List<DownloadItem> GetDownloadItems()
        {
            return new List<DownloadItem>()
            {
                new DownloadItem(){ FileName  ="D:\\TestDownload\\LocalFile1GB_Raw.dat", Url = $"{_dataProvider.Url}/dummyfile/file/size/1073741824"},
                new DownloadItem(){ FileName  ="D:\\TestDownload", Url = $"{_dataProvider.Url}/dummyfile/file/LocalFile100MB_WithContentDisposition.dat/size/104857600"},
                new DownloadItem(){ FileName  ="D:\\TestDownload", Url = $"{_dataProvider.Url}/dummyfile/noheader/file/LocalFile100MB_WithoutHeader.dat?size=104857600"},
                new DownloadItem(){ FileName  ="D:\\TestDownload", Url = $"{_dataProvider.Url}/dummyfile/file/LocalFile100MB.dat?size=104857600"},
            };
        }
        private async Task DownloadAll(IEnumerable<DownloadItem> downloadList, CancellationToken cancelToken)
        {
            foreach (DownloadItem downloadItem in downloadList)
            {
                if (cancelToken.IsCancellationRequested)
                    return;

                // begin download from url
                await DownloadFile(downloadItem).ConfigureAwait(false);
            }
        }
        private async Task<DownloadService> DownloadFile(DownloadItem downloadItem)
        {
            CurrentDownloadConfiguration = GetDownloadConfiguration();
            CurrentDownloadService = CreateDownloadService(CurrentDownloadConfiguration);

            if (string.IsNullOrWhiteSpace(downloadItem.FileName))
            {
                await CurrentDownloadService.DownloadFileTaskAsync(downloadItem.Url, new DirectoryInfo(downloadItem.FolderPath)).ConfigureAwait(false);
            }
            else
            {
                await CurrentDownloadService.DownloadFileTaskAsync(downloadItem.Url, downloadItem.FileName).ConfigureAwait(false);
            }

            return CurrentDownloadService;
        }

        private DownloadService CreateDownloadService(DownloadConfiguration config)
        {
            var downloadService = new DownloadService(config);

            // Provide `FileName` and `TotalBytesToReceive` at the start of each downloads
            downloadService.DownloadStarted += OnDownloadStarted;

            // Provide any information about chunker downloads, 
            // like progress percentage per chunk, speed, 
            // total received bytes and received bytes array to live streaming.
            downloadService.ChunkDownloadProgressChanged += OnChunkDownloadProgressChanged;

            // Provide any information about download progress, 
            // like progress percentage of sum of chunks, total speed, 
            // average speed, total received bytes and received bytes array 
            // to live streaming.
            downloadService.DownloadProgressChanged += OnDownloadProgressChanged;

            // Download completed event that can include occurred errors or 
            // cancelled or download completed successfully.
            downloadService.DownloadFileCompleted += OnDownloadFileCompleted;

            return downloadService;
        }

        private void OnDownloadStarted(object sender, DownloadStartedEventArgs e)
        {
            Progress = 0;
            Message = "";
        }
        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Progress = 10000;

            if (e.Cancelled)
            {
                Message += " CANCELED";
            }
            else if (e.Error != null)
            {
                Message += " ERROR!";
            }
            else
            {
                Message += " DONE";
            }

            ChildConsoleProgresses.Clear();
            Application.Current.BeginInvoke(new Action(() =>
            {
                ChildProgresses.Clear();
            }));
        }
        private void OnChunkDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ChildProgressBar progress = ChildConsoleProgresses.GetOrAdd(e.ProgressId,
                id => new ChildProgressBar() { Id = id });

            progress.Progress = e.ProgressPercentage * 100;


            Application.Current.BeginInvoke(new Action(() =>
            {
                if (!ChildProgresses.Contains(progress))
                {
                    lock (((ICollection)ChildProgresses).SyncRoot)
                    {
                        ChildProgresses.Add(progress);
                    }
                }
            }));

            var activeChunksCount = e.ActiveChunks; // Running chunks count
        }
        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage * 100;
        }

    }

    public class DownloadItem
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }

    public class ChildProgressBar : BindableBase
    {
        public string Id { get; set; }
        private double _progress;//Max 10000
        public double Progress
        {
            get { return _progress; }
            set
            {
                SetProperty(ref _progress, value);
            }
        }
    }
}
