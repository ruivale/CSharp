using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoOS.Platform;
using VideoOS.Platform.Login;
using VideoOS.Platform.EventsAndState;
using VideoOS.Platform.Proxy.RestApi;
using VideoOS.Platform.UI;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using VideoOS.Platform.SDK.StatusClient;
using VideoOS.Platform.SDK.UI.LoginDialog;




namespace MyOwnMilestoneTests.EventsAndStates
{
    internal class EventsAndStatesSubscriber
    {

        private static Guid _integrationId = new Guid("b71d9aff-493e-4597-aec7-5e5f4334bd33");
        private const string _integrationName = "Events and state viewer sample";
        private const string _manufacturerName = "Sample Manufacturer";
        private const string _version = "1.0";


        public EventsAndStatesSubscriber() { 
        }


        public async Task Start()
        {

            // In Program.cs
            //// TODO: Initialize SDK environment and login
            //VideoOS.Platform.SDK.Environment.Initialize();
            ////VideoOS.Platform.SDK.UI.Environment.Initialize();
            ////VideoOS.Platform.SDK.Export.Environment.Initialize();
            ////VideoOS.Platform.SDK.Media.Environment.Initialize();
            ////VideoOS.Platform.SDK.Log.Environment.Initialize();


            // TODO: how to login using non GUI methods?
            var connected = false;
            var loginDialog = new DialogLoginForm(x => connected = x, _integrationId, _integrationName, _version, _manufacturerName);

            if (!connected)
            {
                // Login was cancelled
                //Environment.Exit(0);
                return;
            }


            var loginSettings = LoginSettingsCache.GetLoginSettings(EnvironmentManager.Instance.MasterSite);


            // Create event receiver and session
            var eventReveiver = new EventReceiver();
            var session = EventsAndStateSession.Create(loginSettings, eventReveiver);

            // Add subscription
            var subscription = new[]
            {
                new SubscriptionRule(
                    Modifier.Include,
                    new ResourceTypes(new[]{ "cameras" }),
                    SourceIds.Any,
                    new EventTypes(new[]{ KnownStatusEvents.CommunicationStarted, KnownStatusEvents.CommunicationStopped }))
            };  
            await session.AddSubscriptionAsync(subscription, default);

            // Send initial state as events, if needed
            await session.SendAllStatefulEventsAsync(default);


            // TODO: Run application


            // Dispose session to close the connection
            session.Dispose();

        }
    }

    class EventReceiver : IEventReceiver
    {
        public async Task OnConnectionStateChangedAsync(ConnectionState newState)
        {
            // TODO: Handle connection state change
        }

        public async Task OnEventsReceivedAsync(IEnumerable<Event> events)
        {
            // TODO: Handle events
        }
    }
}
