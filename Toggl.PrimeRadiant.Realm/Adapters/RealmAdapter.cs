using System;
using Realms;
using Toggl.Multivac.Models;

namespace Toggl.PrimeRadiant.Realm
{
    internal sealed class RealmAdapter<TRealmEntity, TModel> : BaseRealmAdapter<TRealmEntity, TModel>
        where TRealmEntity : RealmObject, TModel
        where TModel : IBaseModel, IDatabaseSyncable
    {
        public RealmAdapter(Func<TModel, Realms.Realm, TRealmEntity> convertToRealm)
            : base(convertToRealm, matchEntity)
        {
        }

        private static bool matchEntity(TRealmEntity realmEntry, TModel modelEntity)
            => realmEntry.Id == modelEntity.Id;
    }
}
