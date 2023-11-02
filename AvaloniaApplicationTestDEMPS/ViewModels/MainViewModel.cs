using AvaloniaApplicationTestDEMPS.Data;
using AvaloniaApplicationTestDEMPS.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaApplicationTestDEMPS.ViewModels;
public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Items = new ApplicationContext().Users.ToList();
    }
    [Reactive]
    public List<User> Items { get; set; } = new List<User>();
}
