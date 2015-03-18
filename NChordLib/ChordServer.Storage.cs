using System;

namespace NChordLib
{
    public static partial class ChordServer
    {
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

        /// <summary>
        /// Calls ReplicateKey() remotely, using a default retry value of three.
        /// </summary>
        /// <param name="remoteNode">The remote on which to call the method.</param>
        /// <param name="key">The key to replicate.</param>
        /// <param name="value">The string value to replicate.</param>
        public static void CallReplicateKey(ChordNode remoteNode, ulong key, string value)
        {
            CallReplicateKey(remoteNode, key, value, 3);
        }

        /// <summary>
        /// Calls ReplicateKey remotely.
        /// </summary>
        /// <param name="remoteNode">The remote node on which to call ReplicateKey.</param>
        /// <param name="key">The key to replicate.</param>
        /// <param name="value">The string value to replicate.</param>
        /// <param name="retryCount">The number of retries to attempt.</param>
        public static void CallReplicateKey(ChordNode remoteNode, ulong key, string value, int retryCount)
        {
            ChordInstance instance = ChordServer.GetInstance(remoteNode);

            try
            {
                instance.ReplicateKey(key, value);
            }
            catch (System.Exception ex)
            {
                ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallReplicateKey error: {0}", ex.Message);

                if (retryCount > 0)
                {
                    CallReplicateKey(remoteNode, key, value, --retryCount);
                }
                else
                {
                    ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallReplicateKey failed - error: {0}", ex.Message);
                }
            }
        }

        public static byte[] CallGetFile(ChordNode remoteNode, ChordNode sourceNode, string value)
        {
            return CallGetFile(remoteNode, sourceNode, value, 3);
        }

        public static byte[] CallGetFile(ChordNode remoteNode, ChordNode sourceNode, string value, int retryCount)
        {

            ChordInstance instance = ChordServer.GetInstance(remoteNode);

            try
            {
                return instance.GetFile(value, sourceNode);
            }
            catch (System.Exception ex)
            {
                ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallGetFile error: {0}", ex.Message);

                if (retryCount > 0)
                {
                    return CallGetFile(remoteNode, sourceNode, value, --retryCount);
                }
                else
                {
                    ChordServer.Log(LogLevel.Debug, "Remote Invoker", "CallGetFile failed - error: {0}", ex.Message);
                    return null;
                }
            }
        }

    }
}
