using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Logic.Apis
{
    public class UnZipUrl:ApiBase<UnZipUrlResult>
    {
        public UnZipUrlResult UnZip(string shortUrl)
        {
            UnZipUrlResult _result = new UnZipUrlResult();
            try
            {
                string _long = ShortUrlManagement.Default.Get(shortUrl);
                _result.Return_Code = ResultBase.DEFAULT_RETURN_CODE_SUCCESS;
                _result.Return_Msg = ResultBase.DEFAULT_RETURN_MSG_OK;
                _result.Result = _long;
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
