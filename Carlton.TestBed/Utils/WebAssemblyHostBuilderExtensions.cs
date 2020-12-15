﻿using System;
using System.Reflection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Carlton.Base.Client.State;
using Carlton.TestBed.Client;
using Carlton.TestBed.Components;
using Carlton.TestBed.State;

namespace Carlton.TestBed.Utils
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static void AddCarltonTestBed(this WebAssemblyHostBuilder builder,
            Action<NavTreeBuilder> navTreeAct,
            params Assembly[] assemblies)
        {
            var NavTreeBuilder = new NavTreeBuilder();
            navTreeAct(NavTreeBuilder);
            var options = NavTreeBuilder.Build();
            var state = new TestBedState(options);

            builder.Services.AddSingleton(state);
            builder.Services.AddSingleton<ICarltonStateStore>(state);
            builder.Services.AddScoped<ICarltonRequestFactory, CarltonRequestFactory>();
            builder.Services.AddMediatR(assemblies);

            builder.Services.AddCarltonState(builder =>
                builder.ForComponent<NavTreeViewModel>(_ =>
                {
                    _.AddStateEvent(TestBedState.SELECTED_ITEM);
                    _.AddStateEvent(TestBedState.VIEW_MODEL_CHANGED);
                    _.AddStateEvent(TestBedState.STATUS_CHANGED);
                })
                .ForComponent<ComponentViewerViewModel>(_ =>
                {
                    _.AddStateEvent(TestBedState.SELECTED_ITEM);
                    _.AddStateEvent(TestBedState.VIEW_MODEL_CHANGED);
                })
                .ForComponent<EventConsoleViewModel>(_ =>
                {
                    _.AddStateEvent(TestBedState.COMPONENT_EVENT_ADDED);
                }),
                assemblies);
        }
    }
}
