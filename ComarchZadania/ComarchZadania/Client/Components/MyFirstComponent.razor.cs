using Microsoft.AspNetCore.Components;

namespace ComarchZadania.Client.Components;

public partial class MyFirstComponent : ComponentBase
{
	[Parameter]
	public int CurrentCounterValue { get; set; }
	
	[Parameter]
	public EventCallback<int> CurrentCounterValueChanged { get; set; }

	async void UpdateCurrentCounterValue()
	{
		CurrentCounterValue++;
		await CurrentCounterValueChanged.InvokeAsync(CurrentCounterValue);
	}
}
