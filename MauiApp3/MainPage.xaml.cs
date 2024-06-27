using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp3;

public partial class MainPage
{
	private readonly FooItem[] m_items;

	public MainPage()
	{
		InitializeComponent();

		m_items =
		[
			new FooItem { Name = "Click button bellow 1", Description = "See button bellow (short description)", IsDescriptionVisible = true },
			new FooItem { Name = "Click button bellow 2", Description = "See button bellow (long description long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long long)", IsDescriptionVisible = true }
		];

		listView.ItemsSource = m_items;
	}

	private void ToggleDescription_OnClicked(object? sender, EventArgs e)
	{
		foreach(var item in m_items)
			item.IsDescriptionVisible = !item.IsDescriptionVisible;
	}
}

public sealed class FooItem : ViewModelBase
{
	private string m_name;
	public string Name
	{
		get => m_name;
		set => SetProperty(ref m_name, value);
	}

	private string m_description;
	public string Description
	{
		get => m_description;
		set => SetProperty(ref m_description, value);
	}

	private bool m_isDescriptionVisible;
	public bool IsDescriptionVisible
	{
		get => m_isDescriptionVisible;
		set => SetProperty(ref m_isDescriptionVisible, value);
	}
}

public class ViewModelBase : INotifyPropertyChanged
{
	/// <summary>
	/// Occurs after a property value changes.
	/// </summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Raises the PropertyChanged event if needed.
	/// </summary>
	///
	/// <remarks>
	/// If the propertyName parameter
	///             does not correspond to an existing property on the current class, an
	///             exception is thrown in DEBUG configuration only.
	/// </remarks>
	/// <param name="propertyName">(optional) The name of the property that
	///             changed.</param>
	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new(propertyName));
	}

	protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(value, storage))
			return false;

		storage = value;
		RaisePropertyChanged(propertyName);
		return true;
	}
}