namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string, Coupon> couponsByCode = new Dictionary<string, Coupon>();
        private Dictionary<string, Website> websitesByDomain = new Dictionary<string, Website>();
        private Dictionary<string, List<Coupon>> websiteWithCoupons = new Dictionary<string, List<Coupon>>();
        private Dictionary<string, string> couponWebsite = new Dictionary<string, string>();

        public CouponOperations()
        {
            this.couponsByCode = new Dictionary<string, Coupon>();
            this.websitesByDomain = new Dictionary<string, Website>();
            this.websiteWithCoupons = new Dictionary<string, List<Coupon>>();
            this.couponWebsite = new Dictionary<string, string>();
        }

        public void RegisterSite(Website website)
        {
            if (this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            this.websitesByDomain.Add(website.Domain, website);
            this.websiteWithCoupons.Add(website.Domain, new List<Coupon>());
        }

        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            this.couponsByCode.Add(coupon.Code, coupon);
            this.websiteWithCoupons[website.Domain].Add(coupon);
            this.couponWebsite.Add(coupon.Code, website.Domain);
        }

        public Website RemoveWebsite(string domain)
        {
            if (!this.websitesByDomain.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            Website websiteToRemove = this.websitesByDomain[domain];

            foreach (var coupon in this.websiteWithCoupons[domain])
            {
                this.couponsByCode.Remove(coupon.Code);
                this.couponWebsite.Remove(coupon.Code);
            }

            this.websiteWithCoupons.Remove(domain);
            this.websitesByDomain.Remove(domain);

            return websiteToRemove;
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!this.couponsByCode.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            Coupon couponToRemove = this.couponsByCode[code];


            this.websiteWithCoupons[couponWebsite[code]].Remove(couponToRemove);
            this.couponsByCode.Remove(code);
            this.couponWebsite.Remove(code);

            return couponToRemove;
        }

        public bool Exist(Website website)
        {
            return this.websitesByDomain.ContainsKey(website.Domain);
        }

        public bool Exist(Coupon coupon)
        {
            return this.couponsByCode.ContainsKey(coupon.Code);
        }

        public IEnumerable<Website> GetSites()
        {
            return this.websitesByDomain.Values;
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            return this.websiteWithCoupons[website.Domain];
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return this.couponsByCode.Values
                .OrderByDescending(c => c.Validity)
                .ThenByDescending(c => c.DiscountPercentage);
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!this.websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            if (!this.couponsByCode.ContainsKey(coupon.Code))
            {
                throw new ArgumentException();
            }

            if (this.couponWebsite[coupon.Code] != website.Domain)
            {
                throw new ArgumentException();
            }

            this.couponsByCode.Remove(coupon.Code);
            this.couponWebsite.Remove(coupon.Code);
            this.websiteWithCoupons[website.Domain].Remove(coupon);
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
            return this.websitesByDomain.Values
                .OrderBy(w => w.UsersCount)
                .ThenByDescending(w => websiteWithCoupons[w.Domain].Count);
        }



    }
}
