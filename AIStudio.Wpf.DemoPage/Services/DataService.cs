using AIStudio.Wpf.DemoPage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using Util.Controls.Data;
using Util.Controls.Tools.Converter;

namespace AIStudio.Wpf.DemoPage.Service
{
    public class DataService
    {
        internal static ObservableCollection<TabControlDemoModel> GetTabControlDemoDataList()
        {
            return new ObservableCollection<TabControlDemoModel>
            {
                new TabControlDemoModel
                {
                    Header = "Success",
                    BackgroundToken = ResourceToken.SuccessBrush
                },
                new TabControlDemoModel
                {
                    Header = "Primary",
                    BackgroundToken = ResourceToken.PrimaryBrush
                },
                new TabControlDemoModel
                {
                    Header = "Warning",
                    BackgroundToken = ResourceToken.WarningBrush
                },
                new TabControlDemoModel
                {
                    Header = "Danger",
                    BackgroundToken = ResourceToken.DangerBrush
                },
                new TabControlDemoModel
                {
                    Header = "Info",
                    BackgroundToken = ResourceToken.InfoBrush
                }
            };
        }

        public static List<DemoDataModel> GetDemoDataList()
        {
            var list = new List<DemoDataModel>();
            for (var i = 1; i <= 20; i++)
            {
                var dataList = new List<DemoDataModel>();
                for (var j = 0; j < 3; j++)
                {
                    dataList.Add(new DemoDataModel
                    {
                        Index = j,
                        IsSelected = j % 2 == 0,
                        Name = $"SubName{j}",
                        Type = (DemoType)j
                    });
                }
                var model = new DemoDataModel
                {
                    Index = i,
                    IsSelected = i % 2 == 0,
                    Name = $"Name{i}",
                    Type = (DemoType)i,
                    DataList = dataList,
                    ImgPath = $"/AIStudio.Wpf.DemoPage;component/Resources/Img/Avatar/avatar{i % 6 + 1}.png",
                    Remark = new string(i.ToString()[0], 10)
                };
                list.Add(model);
            }

            return list;
        }

        public static List<DemoDataModel> GetDemoDataList(int count)
        {
            var list = new List<DemoDataModel>();
            for (var i = 1; i <= count; i++)
            {
                var index = i % 6 + 1;
                var model = new DemoDataModel
                {
                    Index = i,
                    IsSelected = i % 2 == 0,
                    Name = $"Name{i}",
                    Type = (DemoType)index,
                    ImgPath = $"/AIStudio.Wpf.DemoPage;component/Resources/Img/Avatar/avatar{index}.png",
                    Remark = new string(i.ToString()[0], 10)
                };
                list.Add(model);
            }

            return list;
        }

        internal static List<string> GetComboBoxDemoDataList()
        {
            var converter = new StringRepeatConverter();
            var list = new List<string>();
            for (var i = 1; i <= 9; i++)
            {
                list.Add($"{converter.Convert("Text", null, i, CultureInfo.CurrentCulture)}{i}");
            }

            return list;
        }

        internal static List<AvatarModel> GetContributorDataList()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", "request");
            var list = new List<AvatarModel>();
            try
            {
                var json = client.DownloadString(new Uri("https://api.github.com/repos/nabian/handycontrol/contributors"));
                var objList = JsonConvert.DeserializeObject<List<dynamic>>(json);
                list.AddRange(objList.Select(item => new AvatarModel
                {
                    DisplayName = item.login,
                    AvatarUri = item.avatar_url,
                    Link = item.html_url
                }));
            }
            catch
            {
                // ignored
            }
            return list;
        }

        internal static List<AvatarModel> GetBlogDataList()
        {
            return new List<AvatarModel>
            {
                new AvatarModel
                {
                    DisplayName = "林德熙",
                    AvatarUri = "https://avatars3.githubusercontent.com/u/16054566?s=400&v=4",
                    Link = "https://blog.lindexi.com/"
                },
                new AvatarModel
                {
                    DisplayName = "吕毅",
                    AvatarUri = "https://avatars2.githubusercontent.com/u/9959623?s=400&v=4",
                    Link = "https://blog.walterlv.com/"
                },
                new AvatarModel
                {
                    DisplayName = "DinoChan",
                    AvatarUri = "https://avatars1.githubusercontent.com/u/6076257?s=400&v=4",
                    Link = "https://www.cnblogs.com/dino623/"
                },
                new AvatarModel
                {
                    DisplayName = "noctwolf",
                    AvatarUri = "https://avatars3.githubusercontent.com/u/21022467?s=400&v=4",
                    Link = "https://www.cnblogs.com/noctwolf/"
                }
            };
        }

        internal static List<AvatarModel> GetProjectDataList()
        {
            return new List<AvatarModel>
            {
                new AvatarModel
                {
                    DisplayName = "phpEnv",
                    AvatarUri = "https://cdn.phpenv.cn:444/logo.png",
                    Link = "https://www.phpenv.cn/"
                },
                new AvatarModel
                {
                    DisplayName = "AutumnBox",
                    AvatarUri = "https://www.atmb.top/images/leaves.png",
                    Link = "https://github.com/zsh2401/AutumnBox"
                }
            };
        }

        internal static List<AvatarModel> GetWebsiteDataList()
        {
            return new List<AvatarModel>
            {
                new AvatarModel
                {
                    DisplayName = "Dotnet9",
                    AvatarUri = "https://pic.cnblogs.com/avatar/1663243/20191124121029.png",
                    Link = "https://dotnet9.com/"
                }
            };
        }

        internal static ObservableCollection<CardModel> GetCardDataList()
        {
            return new ObservableCollection<CardModel>
            {
                new CardModel
                {
                    Header = "Atomic",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/1.jpg",
                    Footer = "Stive Morgan"
                },
                new CardModel
                {
                    Header = "Zinderlong",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/2.jpg",
                    Footer = "Zonderling"
                },
                new CardModel
                {
                    Header = "Busy Doin' Nothin'",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/3.jpg",
                    Footer = "Ace Wilder"
                },
                new CardModel
                {
                    Header = "Wrong",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/4.jpg",
                    Footer = "Blaxy Girls"
                },
                new CardModel
                {
                    Header = "The Lights",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/5.jpg",
                    Footer = "Panda Eyes"
                },
                new CardModel
                {
                    Header = "EA7-50-Cent Disco",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/6.jpg",
                    Footer = "еяхат музыка"
                },
                new CardModel
                {
                    Header = "Monsters",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/7.jpg",
                    Footer = "Different Heaven"
                },
                new CardModel
                {
                    Header = "Gangsta Walk",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/8.jpg",
                    Footer = "Illusionize"
                },
                new CardModel
                {
                    Header = "Won't Back Down",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/9.jpg",
                    Footer = "Boehm / Benjamin Francis Leftwich"
                },
                new CardModel
                {
                    Header = "Katchi",
                    Content = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/10.jpg",
                    Footer = "Ofenbach / Nick Waterhouse"
                }
            };
        }

        internal static CardModel GetCardData()
        {
            return new CardModel
            {
                Content = $"/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/{DateTime.Now.Second % 10 + 1}.jpg"
            };
        }

        internal static List<StepBarDemoModel> GetStepBarDemoDataList()
        {
            return new List<StepBarDemoModel>
            {
                new StepBarDemoModel
                {
                    Header = $"Step1",
                    Content = "Register"
                },
                new StepBarDemoModel
                {
                    Header = $"Step2",
                    Content = "BasicInfo"
                },
                new StepBarDemoModel
                {
                    Header = $"Step3",
                    Content = "UploadFile"
                },
                new StepBarDemoModel
                {
                    Header = $"Step4",
                    Content = "Complete"
                }
            };
        }

        internal static ObservableCollection<CoverViewDemoModel> GetCoverViewDemoDataList()
        {
            return new ObservableCollection<CoverViewDemoModel>
            {
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/1.jpg",
                    BackgroundToken = ResourceToken.SuccessBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/2.jpg",
                    BackgroundToken = ResourceToken.AccentBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/3.jpg",
                    BackgroundToken = ResourceToken.WarningBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/4.jpg",
                    BackgroundToken = ResourceToken.DangerBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/5.jpg",
                    BackgroundToken = ResourceToken.SuccessBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/6.jpg",
                    BackgroundToken = ResourceToken.AccentBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/7.jpg",
                    BackgroundToken = ResourceToken.InfoBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/8.jpg",
                    BackgroundToken = ResourceToken.WarningBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/9.jpg",
                    BackgroundToken = ResourceToken.AccentBrush
                },
                new CoverViewDemoModel
                {
                    ImgPath = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/10.jpg",
                    BackgroundToken = ResourceToken.DangerBrush
                }
            };
        }

        public static List<DemoInfoModel> GetDemoInfo()
        {
            var infoList = new List<DemoInfoModel>();

            var stream = Application.GetResourceStream(new Uri("/AIStudio.Wpf.DemoPage;component/DemoInfo.json", UriKind.Relative))?.Stream;
            if (stream == null) return infoList;

            string jsonStr;
            using (var reader = new StreamReader(stream))
            {
                jsonStr = reader.ReadToEnd();
            }

            var jsonObj = JsonConvert.DeserializeObject<dynamic>(jsonStr);
            foreach (var item in jsonObj)
            {
                var titleKey = (string)item.title;
                var title = titleKey;
                var list = Convert2DemoItemList(item.demoItemList);
                infoList.Add(new DemoInfoModel
                {
                    Key = titleKey,
                    Title = title,
                    DemoItemList = list
                });
            }

            return infoList;
        }

        private static List<DemoItemModel> Convert2DemoItemList(dynamic list)
        {
            var resultList = new List<DemoItemModel>();

            foreach (var item in list)
            {
                var name = (string)item[0];
                string targetCtlName = item[1];
                string imageName = item[2];
                var isNew = !string.IsNullOrEmpty((string)item[3]);

                resultList.Add(new DemoItemModel
                {
                    Name = name,
                    TargetCtlName = targetCtlName,
                    ImageName = $"/AIStudio.Wpf.DemoPage;component/Resources/Img/LeftMainContent/{imageName}.png",
                    IsNew = isNew
                });
            }

            return resultList;
        }

    }
}