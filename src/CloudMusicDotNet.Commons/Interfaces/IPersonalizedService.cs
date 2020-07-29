﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 个性化推荐服务
    /// </summary>
    public interface IPersonalizedService
    {
        /// <summary>
        /// 推荐电台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> DjProgram(string data);

        /// <summary>
        /// 推荐MV
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Mv(string data);

        /// <summary>
        /// 推荐新歌
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> NewSong(string data);

        /// <summary>
        /// 独家放送
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> PrivateContent(string data);

        /// <summary>
        /// 推荐歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> PlayList(string data);

        /// <summary>
        /// 推荐节目
        /// </summary>
        /// <param name="cateId">类别id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        Task<string> Program(string cateId, int limit, int offset);
    }
}
