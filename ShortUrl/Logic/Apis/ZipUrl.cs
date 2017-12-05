using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Logic.Apis
{
    public class ZipUrl : ApiBase<ZipUrlResult>
    {
        public ZipUrlResult Zip(string longUrl)
        {
            ZipUrlResult _result = new ZipUrlResult();
            try
            {
                string _short = ShortUrlManagement.Default.Add(longUrl);
                _result.Return_Code = ResultBase.DEFAULT_RETURN_CODE_SUCCESS;
                _result.Return_Msg = ResultBase.DEFAULT_RETURN_MSG_OK;
                _result.Result = _short;
            }
            catch (SqlException)
            {
                _result.Return_Code = ResultBase.DEFAULT_RETURN_CODE_FAIL;
                _result.Return_Msg = "服务器内部错误";
            }
            catch (Exception ex)
            {
                _result.Return_Code = ResultBase.DEFAULT_RETURN_CODE_FAIL;
                _result.Return_Msg = ex.Message;
            }
            return _result;
        }
    }
}
