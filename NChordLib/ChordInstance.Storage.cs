/*
 * ChordInstance.Storage.cs:
 * 
 *  Contains private data structure and public methods for
 *  key-value data storage.
 * 
 */

using System;
using System.Collections.Generic;

namespace NChordLib
{
    public partial class ChordInstance : MarshalByRefObject
    {
        /// <summary>
        /// The data structure used to store string data given a 
        /// 64-bit (ulong) key value.
        /// </summary>
        private SortedList<ulong, string> m_DataStore = new SortedList<ulong, string>();

        public void AddKey(string value)
        {
            ulong key = ChordServer.GetHash(value);

            // Replicate the key to the local datastore
            ReplicateKey(key, value);

            // Replicate the key to a remote datastore
            ReplicateRemote(value, ChordServer.GetSuccessor(ChordServer.LocalNode), ChordServer.LocalNode);
        }

        public void AddKey(string value, ChordNode sourceNode)
        {
            ulong key = ChordServer.GetHash(value);

            // Replicate the key to the local datastore
            ReplicateKey(key, value);

            // Replicate the key to a remote datastore if the current local node isn't 
            // the node which initiated the request; otherwise stop the request.
            if (sourceNode.ID != ChordServer.LocalNode.ID)
            {
                ReplicateRemote(value, ChordServer.GetSuccessor(ChordServer.LocalNode), sourceNode);
            }
        }

        public string FindKey(ulong key)
        {
            if (this.m_DataStore.ContainsKey(key))
            {
                return m_DataStore[key];
            }

            return FindKeyRemote(key, ChordServer.GetSuccessor(ChordServer.LocalNode), ChordServer.LocalNode);
        }

        public string FindKey(ulong key, ChordNode sourceNode)
        {
            if (this.m_DataStore.ContainsKey(key))
            {
                return m_DataStore[key];
            }

            if (sourceNode.ID != ChordServer.LocalNode.ID)
            {
                return FindKeyRemote(key, ChordServer.GetSuccessor(ChordServer.LocalNode), sourceNode);
            }
            else
            {
                return string.Empty;
            }
        }

        public string FindKeyRemote(ulong key, ChordNode remoteNode, ChordNode sourceNode)
        {
            ChordServer.Log(LogLevel.Info, "Local Invoker", "Searching for key {0} on node {1}", key, remoteNode);
            return ChordServer.CallFindKey(remoteNode, sourceNode, key);
        }

        /// <summary>
        /// Add the given key/value pair as replicas to the local store.
        /// </summary>
        /// <param name="key">The key to replicate.</param>
        /// <param name="value">The value to replicate.</param>
        public void ReplicateKey(ulong key, string value)
        {
            // add the key/value pair to the local
            // data store regardless of ownership
            if (!this.m_DataStore.ContainsKey(key))
            {
                this.m_DataStore.Add(key, value);
            }
        }

        /// <summary>
        /// Add the given value to a remote datastore.
        /// </summary>
        /// <param name="value">The value to replicate.</param>
        /// <param name="remoteNode">The node to send the request to.</param>
        /// <param name="sourceNode">The node which initiated the request.</param>
        public void ReplicateRemote(string value, ChordNode remoteNode, ChordNode sourceNode)
        {
            ChordServer.Log(LogLevel.Info, "Local Invoker", "Replicating value {0} on node {1}", value, remoteNode);
            ChordServer.CallAddKey(remoteNode, sourceNode, value);
        }

    }
}