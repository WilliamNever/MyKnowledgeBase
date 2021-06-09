using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Pages
{
    public class CounterBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Parameter]
        public int currentCount { get; set; } = 0;

        protected bool isShow = true;

        protected void IncrementCount()
        {
            currentCount++;
        }
        protected void SOH()
        {
            isShow = !isShow;
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
