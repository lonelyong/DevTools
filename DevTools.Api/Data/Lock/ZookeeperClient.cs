using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using org.apache.zookeeper;

namespace DevTools.Api.Data
{
	public class ZookeeperClient : IDistributedLocker
	{
		private ZooKeeper _zk;

		public ZookeeperClient()
		{

		}

		public object GetLock(string lockName)
		{
			throw new NotImplementedException();
		}

		public void ReleaseLock(string lockName)
		{
			throw new NotImplementedException();
		}
	}
}
