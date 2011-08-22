using System.ServiceModel;
using System.ServiceModel.Description;

namespace NCloudWatch
{
    public static class ManagementServiceClient
    {
        /// <summary>
        /// Creates an <see cref="IManagementService"/> client.
        /// </summary>
        /// <returns></returns>
        public static IManagementService Create()
        {
            var factory = new ChannelFactory<IManagementService>(new WebHttpBinding(), ManagementService.LocalEndpointUrl);
            factory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            return factory.CreateChannel();
        }
    }
}