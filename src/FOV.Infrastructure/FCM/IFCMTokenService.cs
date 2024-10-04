using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Infrastructure.FCM;
public interface IFCMTokenService
{
    public ValueTask SaveFCMToken(Guid userId, string token);

    public List<string> GetFCMTokenList();

    public string GetFCMToken(Guid userId);
}
