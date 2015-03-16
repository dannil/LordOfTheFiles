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
            ChordServer.Log(LogLevel.Debug, "Local Invoker", "Calling remote node {0} for value {1}", remoteNode, value);
            //Console.WriteLine("Calling remote node " + remoteNode.ToString() + " for value " + value);
            ChordServer.CallAddKey(remoteNode, sourceNode, value);
        }

        /// <summary>
        /// Retrieve the string value for a given ulong
        /// key.
        /// </summary>
        /// <param name="key">The key whose value should be returned.</param>
        /// <returns>The string value for the given key, or an empty string if not found.</returns>
        public string FindKey(ulong key)
        {
            if (this.m_DataStore.ContainsKey(key))
            {
                return m_DataStore[key];
            }

            ChordNode successor = ChordServer.GetSuccessor(ChordServer.LocalNode);

            Console.WriteLine("Calling remote node " + successor.ToString() + " for key " + key);
            return ChordServer.CallFindKey(successor, key);

            // determine the owning node for the key
            //ChordNode owningNode = ChordServer.CallFindSuccessor(key);

            //if (owningNode != ChordServer.LocalNode)
            //{
            //     //if this is not the owning node, call
            //     //FindKey on the remote owning node
            //    return ChordServer.CallFindKey(owningNode, key);
            //}
            //else
            //{
            //     //if this is the owning node, check
            //     //to see if the key exists in the data store
            //    if (this.m_DataStore.ContainsKey(key))
            //    {
            //         //if the key exists, return the value
            //        return this.m_DataStore[key];
            //    }
            //    else
            //    {
            //         //if the key does not exist, return empty string
            //        return string.Empty;
            //    }
            //}
        }

    }
}