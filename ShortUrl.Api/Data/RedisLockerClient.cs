using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	public class RedisLockerClient : IDistributedLocker
	{
		public object GetLock(string lockName)
		{
			throw new NotImplementedException();
		}

		public void ReleaseLock(string lockName)
		{
			throw new NotImplementedException();
		}
	}

	class Class
	{
		interface I1<in T>
		{
			void GetT(T t);
		}
		interface I2<out T>
		{
			T GetT();
		}
		class C1<T> : I1<T>
		{
			public void GetT(T t)
			{
				throw new NotImplementedException();
			}
		}
		class C2<T> : I2<T>
		{
			public T GetT()
			{
				throw new NotImplementedException();
			}
		}
		class Fruit
		{

		}
		class Apple : Fruit
		{

		}

		I2<Fruit> i2 = new C2<Apple>();
		I1<Apple> i1 = new C1<Fruit>();
	}
}
