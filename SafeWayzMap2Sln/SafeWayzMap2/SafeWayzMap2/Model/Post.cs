using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SafeWayzMap2.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Incident { get; set; }
        public string IncidentDescription { get; set; }
        public ObservableCollection<string> Comments { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}

/*  
 {
 "id":1,
 "area":"Eerste River",
 "incident":"Shooting",
 "incidentDescription":"There was a shooting at Eerste River.",
 "comment":null,
 "upvotesAmount":0,
 "dislikesAmount":0
 },
 {
 "id":2,
 "area":"Kuils River",
 "incident":"Stabbing",
 "incidentDescription":"There was a shooting at Kuils River.",
 "comment":null,
 "upvotesAmount":0,
 "dislikesAmount":0
 }
 ]
 */
