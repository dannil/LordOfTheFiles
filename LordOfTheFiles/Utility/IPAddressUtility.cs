using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace LordOfTheFiles.Utility
{
    /// <summary>
    /// Contains functionality for fetching internal and external IP address to be used
    /// in the application.
    /// </summary>
    public class IPAddressUtility
    {
        private int port;

        /// <summary>
        /// Default constructor
        /// </summary>
        public IPAddressUtility()
        {
            port = 8861;
        }

        /// <summary>
        /// Return the local IPv4 for the specified network interface.
        /// </summary>
        /// <param name="type">The type of network interface</param>
        /// <returns>The IPv4-address for the specified network interface.</returns>
        private IPAddress GetLocalIPv4(NetworkInterfaceType type)
        {
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ip.Address;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Return the local IPv6 for the specified network interface.
        /// </summary>
        /// <param name="type">The type of network interface</param>
        /// <returns>The IPv6-address for the specified network interface.</returns>
        private IPAddress GetLocalIPv6(NetworkInterfaceType type)
        {
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            return ip.Address;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the prefered local IPv4. Prefers wired connections over wireless.
        /// </summary>
        public IPAddress LocalIPv4
        {
            get 
            {
                // Prefer wired connection over wireless

                IPAddress ethernetAddress = GetLocalIPv4(NetworkInterfaceType.Ethernet);
                IPAddress wirelessAddress = GetLocalIPv4(NetworkInterfaceType.Wireless80211);

                if (ethernetAddress != null)
                {
                    return ethernetAddress;
                }
                else if (wirelessAddress != null)
                {
                    return wirelessAddress;
                }
                return null;
            }
            private set { }
        }

        /// <summary>
        /// Returns the prefered local IPv6. Prefers wired connections over wireless.
        /// </summary>
        public IPAddress LocalIPv6
        {
            get
            {
                // Prefer wired connection over wireless

                IPAddress ethernetAddress = GetLocalIPv6(NetworkInterfaceType.Ethernet);
                IPAddress wirelessAddress = GetLocalIPv6(NetworkInterfaceType.Wireless80211);

                if (ethernetAddress != null)
                {
                    return ethernetAddress;
                }
                else if (wirelessAddress != null)
                {
                    return wirelessAddress;
                }
                return null;
            }
            private set { }
        }

        /// <summary>
        /// Returns the external IPv4.
        /// </summary>
        public IPAddress ExternalIPv4
        {
            get
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        return IPAddress.Parse(client.DownloadString("http://v4.ipv6-test.com/api/myip.php"));
                    }
                }
                catch
                {
                    return null;
                }
            }
            private set { }
        }

        /// <summary>
        /// Returns the external IPv6.
        /// </summary>
        public IPAddress ExternalIPv6
        {
            get
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        return IPAddress.Parse(client.DownloadString("http://v6.ipv6-test.com/api/myip.php"));
                    }
                }
                catch
                {
                    return null;
                }
            }
            private set { }
        }

        /// <summary>
        /// Property for port
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

    }
}
