using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_InsuranceClaimMenu
{
    class ClaimRepository
    {
        Queue<Claim> claimQueue = new Queue<Claim>();
        public void NewClaim(Claim claim)
        {
            claimQueue.Enqueue(claim);
        }
        public Queue<Claim> DisplayClaims()
        {
            return claimQueue;
        }
        public void RemoveClaim()
        {
            claimQueue.Dequeue();
        }
    }
}
