using System.Runtime.CompilerServices;

namespace MauiApp3;

public sealed class MyViewCell : ViewCell
{
	private readonly Label m_nameLabel;
	private readonly Label m_descriptionLabel;

	#region Name BindableProperty

	public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(MyViewCell), String.Empty);

	public string Name
	{
		get => (string)GetValue(NameProperty);
		set => SetValue(NameProperty, value);
	}

	#endregion

	#region Description BindableProperty

	public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(MyViewCell), String.Empty);

	public string Description
	{
		get => (string)GetValue(DescriptionProperty);
		set => SetValue(DescriptionProperty, value);
	}

	#endregion

	#region IsDescriptionVisible BindableProperty

	public static readonly BindableProperty IsDescriptionVisibleProperty = BindableProperty.Create(nameof(IsDescriptionVisible), typeof(bool), typeof(MyViewCell), true);

	public bool IsDescriptionVisible
	{
		get => (bool)GetValue(IsDescriptionVisibleProperty);
		set => SetValue(IsDescriptionVisibleProperty, value);
	}

	#endregion

	public MyViewCell()
	{
		var grid = new Grid
		{
			RowDefinitions =
			[
				new() { Height = GridLength.Auto },
				new() { Height = GridLength.Auto }
			],
		};

		m_nameLabel = new()
		{
			LineBreakMode = LineBreakMode.TailTruncation,
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center
		};

		m_descriptionLabel = new()
		{
			LineBreakMode = LineBreakMode.WordWrap,
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center
		};
		Grid.SetRow(m_descriptionLabel, 1);

		grid.Children.Add(m_nameLabel);
		grid.Children.Add(m_descriptionLabel);

		View = grid;
	}

	protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		if (propertyName == nameof(Name))
			m_nameLabel.Text = Name;
		else if (propertyName == nameof(Description))
			m_descriptionLabel.Text = Description;
		else if (propertyName == nameof(IsDescriptionVisible))
		{
			m_descriptionLabel.IsVisible = IsDescriptionVisible;
			ForceUpdateSize();
		}

		base.OnPropertyChanged(propertyName);
	}
}