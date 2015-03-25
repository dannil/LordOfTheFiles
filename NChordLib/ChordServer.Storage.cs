using System;
using System.Collections.Generic;

namespace NChordLib
{
    public static partial class ChordServer
    {
        public static SortedList<ulong, string> CallGetDHT(ChordNode remoteNode, ChordNode sourceNode)
        {
            return CallGetDHT(remoteNode, sourceNode);
        }

        public static SortedList<ulong, string> CallGetDHT(ChordNode remoteNode, ChordNode sourceNode, int retryCount)
        {
            ChordInstance instance = ChordServer.GetInstance(remoteNode);

            try
            {
                return instance.GetDHT(sourceNode);
            }
            catch (System.Exception ex)
            {
                ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallGetDHT error: {0}", ex.Message);

                if (retryCount > 0)
                {
                    return CallGetDHT(remoteNode, sourceNode, --retryCount);
                }
                else
                {
                    ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallGetDHT failed - error: {0}", ex.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Calls AddKey() remotely, using a default retry value of three.
        /// </summary>
        /// <param name="remoteNode">The remote on which to call the method.</param>
        /// <param name="value">The string value to add.</param>
        public static void CallAddKey(ChordNode remoteNode, ChordNode sourceNode, string value)
        {
            CallAddKey(remoteNode, sourceNode, value, 3);
        }

        /// <summary>
        /// Calls AddKey remotely.
        /// </summary>
        /// <param name="remoteNode">The remote node on which to call AddKey.</param>
        /// <param name="value">The string value to add.</param>
        /// <param name="retryCount">The number of retries to attempt.</param>
        public static void CallAddKey(ChordNode remoteNode, ChordNode sourceNode, string value, int retryCount)
        {
            ChordInstance instance = ChordServer.GetInstance(remoteNode);

            try
            {
                instance.AddKey(value, sourceNode);
            }
            catch (System.Exception ex)
            {
                ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallAddKey error: {0}", ex.Message);

                if (retryCount > 0)
                {
                    CallAddKey(remoteNode, sourceNode, value, --retryCount);
                }
                else
                {
                    ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallAddKey failed - error: {0}", ex.Message);
                }
            }
        }

        /// <summary>
        /// Calls FindKey() remotely, using a default retry value of three.
        /// </summary>
        /// <param name="remoteNode">The remote on which to call the method.</param>
        /// <param name="key">The key to look up.</param>
        /// <returns>The value corresponding to the key, or empty string if not found.</returns>
        public static string CallFindKey(ChordNode remoteNode, ChordNode sourceNode, ulong key)
        {
            return CallFindKey(remoteNode, sourceNode, key, 3);
        }

        /// <summary>
        /// Calls FindKey remotely.
        /// </summary>
        /// <param name="remoteNode">The remote node on which to call FindKey.</param>
        /// <param name="key">The key to look up.</param>
        /// <param name="retryCount">The number of retries to attempt.</param>
        /// <returns>The value corresponding to the key, or empty string if not found.</returns>
        public static string CallFindKey(ChordNode remoteNode, ChordNode sourceNode, ulong key, int retryCount)
        {
            ChordInstance instance = ChordServer.GetInstance(remoteNode);

            try
            {
                return instance.FindKey(key, sourceNode);
            }
            catch (System.Exception ex)
            {
                ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallFindKey error: {0}", ex.Message);

                if (retryCount > 0)
                {
                    return CallFindKey(remoteNode, sourceNode, key, --retryCount);
                }
                else
                {
                    ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallFindKey failed - error: {0}", ex.Message);
                    return string.Empty;
                }
            }
        }

        public static void CallDeleteKey(ChordNode remoteNode, ChordNode sourceNode, ulong key)
        {
            CallDeleteKey(remoteNode, sourceNode, key, 3);
        }

        public static void CallDeleteKey(ChordNode remoteNode, ChordNode sourceNode, ulong key, int retryCount)
        {
            ChordInstance instance = ChordServer.GetInstance(remoteNode);

            try
            {
                instance.DeleteKey(key, sourceNode);
            }
            catch (System.Exception ex)
            {
                ChordServer.Log(LogLevel.Debug, "Remote Invoker", "DeleteKey error: {0}", ex.Message);

                if (retryCount > 0)
                {
                    CallDeleteKey(remoteNode, sourceNode, key, --retryCount);
                }
                else
                {
                    ChordServer.Log(LogLevel.Debug, "Remote Invoker", "DeleteKey failed - error: {0}", ex.Message);
                }
            }
        }

        public static byte[] CallFindFile(ChordNode remoteNode, ChordNode sourceNode, string name)
        {
            return CallFindFile(remoteNode, sourceNode, name, 3);
        }

        public static byte[] CallFindFile(ChordNode remoteNode, ChordNode sourceNode, string name, int retryCount)
        {

            ChordInstance instance = ChordServer.GetInstance(remoteNode);

            try
            {
                return instance.FindFile(name, sourceNode);
            }
            catch (System.Exception ex)
            {
                ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallFindFile error: {0}", ex.Message);

                if (retryCount > 0)
                {
                    return CallFindFile(remoteNode, sourceNode, name, --retryCount);
                }
                else
                {
                    ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallFindFile failed - error: {0}", ex.Message);
                    return null;
                }
            }
        }

        public static void CallDeleteFile(ChordNode remoteNode, ChordNode sourceNode, string name)
        {
            CallDeleteFile(remoteNode, sourceNode, name, 3);
        }

        public static void CallDeleteFile(ChordNode remoteNode, ChordNode sourceNode, string name, int retryCount)
        {
            ChordInstance instance = ChordServer.GetInstance(remoteNode);

            try
            {
                instance.DeleteFile(name, sourceNode);
            }
            catch (System.Exception ex)
            {
                ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallDeleteFile error: {0}", ex.Message);

                if (retryCount > 0)
                {
                    CallDeleteFile(remoteNode, sourceNode, name, --retryCount);
                }
                else
                {
                    ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallDeleteFile failed - error: {0}", ex.Message);
                }
            }
        }

    }
}
