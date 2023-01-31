using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public interface ISwitchableService : IService
    {
        void EnabledService();
        void DisabledService();

        bool GetIsActiveService
        {
            get;
        }
    }
}