
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Common
{
	/// <summary>
	/// 缓存相关的操作类
    /// Copyright (C) BasicPlatform
	/// </summary>
	public   class DataCache
	{
		private IMemoryCache memoryCache;

		public  DataCache(IMemoryCache _memoryCache) {
			memoryCache = _memoryCache;
		}
		/// <summary>
		/// 获取当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public object GetCache(string CacheKey)
		{
			return memoryCache.Get<string>(CacheKey);  
		}

		/// <summary>
		/// 设置当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public  void SetCache(string CacheKey, object objObject)
		{
			memoryCache.Set(CacheKey, objObject); 
		}

		/// <summary>
		/// 设置当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public void SetCache(string CacheKey, object objObject, DateTimeOffset absoluteExpiration)
		{ 
			memoryCache.Set(CacheKey, objObject,absoluteExpiration);
		}

		/// <summary>
		/// 移除当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		public void RemoveCahche(string CacheKey)
		{ 
			memoryCache.Remove(CacheKey);
		}

	}
}
