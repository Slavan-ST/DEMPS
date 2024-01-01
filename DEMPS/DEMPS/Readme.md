Данная библиотека предоставляет простую навигацию для проекта
Использование:
1. в классе App в методе OnFrameworkInitializationCompleted() добавить строку для старта приложения:									DEMPS.AppConfig.StartApp(ApplicationLifetime, new MainView());  //MainView - стартовый контрол/страница
2. Добавить необходимые страницы в словарь:
						DEMPS.Services.Navigation.Add("NextPage", new MainView()); 
						1. NextPage - название для дальнейшего перехода
						2. MainView - какая-либо страница
3. Совершить переходя там где это необходимо:
						DEMPS.Services.Navigation.Go("NextPage"); //название для дальнейшего перехода
