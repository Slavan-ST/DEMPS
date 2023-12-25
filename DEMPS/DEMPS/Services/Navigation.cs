using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using DEMPS.ViewModels;
using ReactiveUI;

namespace DEMPS.Services
{
    public static class Navigation
    {
        public static MainNavigationPageViewModel? NavigationView { get; set; }
        private static Dictionary<string, ContentControl> Pages { get; set; } = new Dictionary<string, ContentControl>();

        /// <summary>
        /// изменить/добавить стартовую страницу
        /// </summary>
        /// <param name="startPage"></param>
        public static void SetStartPage(ContentControl startPage)
        {
            if (Pages["first"] == null)
            {
                Pages.Add("first", startPage);
            }
            else
            {
                Pages["first"] = startPage;
            }
        }
        /// <summary>
        /// получить стартовую страницу
        /// </summary>
        /// <returns></returns>
        public static ContentControl? GetStartPage()
        {
            return Pages["first"];
        }
        /// <summary>
        /// Добавить в навигацию новую страницу
        /// </summary>
        /// <param name="namePageForNavigate">имя страницы для обращения к ней</param>
        /// <param name="page">сама вьюшка</param>
        public static void Add(string namePageForNavigate, ContentControl page)
        {
            Pages.Add(namePageForNavigate, page);
        }
        /// <summary>
        /// переход к вьюшке с установлением нового DataContext
        /// </summary>
        /// <param name="page"></param>
        /// <param name="dataContext"></param>
        public static void Go(string page, object? dataContext)
        {
            Go(page);
            NavigationView!.Page.DataContext = dataContext;
        }
        /// <summary>
        /// переход к вьюшке
        /// </summary>
        /// <param name="page"></param>
        public static void Go(string page)
        {
            var pageView = Pages[page];
            if (pageView == null)
            {
                NavigationView!.Page = Pages.First().Value!;
            }
            else
            {
                NavigationView!.Page = pageView;
            }
        }
    }
}
