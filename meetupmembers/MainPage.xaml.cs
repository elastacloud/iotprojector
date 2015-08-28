using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace meetupmembers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string rawJson = @"{'results':[{'created':1439591375000,'response':'no','guests':0,'member':{'member_id':101758102,'name':'Chris Dunkel'},'rsvp_id':1565579014,'mtime':1439591375000,'event':{'name':'repeating test','id':'zzfsglytmbjc','time':1443319200000,'event_url':'http:\/\/www.meetup.com\/Meetup-API-Testing\/events\/222086589\/'},'group':{'join_mode':'open','created':1440671866161,'group_lon':-73.98999786376953,'id':1556336,'urlname':'Meetup-API-Testing','group_lat':40.70000076293945}},{'created':1439287136000,'response':'no','member_photo':{'highres_link':'http:\/\/photos3.meetupstatic.com\/photos\/member\/9\/9\/5\/0\/highres_247179248.jpeg','photo_id':247179248,'photo_link':'http:\/\/photos1.meetupstatic.com\/photos\/member\/9\/9\/5\/0\/member_247179248.jpeg','thumb_link':'http:\/\/photos3.meetupstatic.com\/photos\/member\/9\/9\/5\/0\/thumb_247179248.jpeg'},'guests':0,'member':{'member_id':119955042,'name':'Kumaran Vellaisamy'},'rsvp_id':1564973839,'mtime':1439287160000,'event':{'name':'repeating test','id':'zzfsglytmbjc','time':1443319200000,'event_url':'http:\/\/www.meetup.com\/Meetup-API-Testing\/events\/222086589\/'},'group':{'join_mode':'open','created':1440671866161,'group_lon':-73.98999786376953,'id':1556336,'urlname':'Meetup-API-Testing','group_lat':40.70000076293945}},{'created':1439918041000,'response':'yes','member_photo':{'highres_link':'http:\/\/photos2.meetupstatic.com\/photos\/member\/b\/e\/8\/4\/highres_248928772.jpeg','photo_id':248928772,'photo_link':'http:\/\/photos4.meetupstatic.com\/photos\/member\/b\/e\/8\/4\/member_248928772.jpeg','thumb_link':'http:\/\/photos2.meetupstatic.com\/photos\/member\/b\/e\/8\/4\/thumb_248928772.jpeg'},'guests':0,'member':{'member_id':191491835,'name':'Brian Kamptha'},'rsvp_id':1566146593,'mtime':1439918041000,'event':{'name':'repeating test','id':'zzfsglytmbjc','time':1443319200000,'event_url':'http:\/\/www.meetup.com\/Meetup-API-Testing\/events\/222086589\/'},'group':{'join_mode':'open','created':1440671866161,'group_lon':-73.98999786376953,'id':1556336,'urlname':'Meetup-API-Testing','group_lat':40.70000076293945}},{'created':1433211423000,'response':'no','member_photo':{'highres_link':'http:\/\/photos4.meetupstatic.com\/photos\/member\/7\/3\/d\/8\/highres_246269656.jpeg','photo_id':246269656,'photo_link':'http:\/\/photos2.meetupstatic.com\/photos\/member\/7\/3\/d\/8\/member_246269656.jpeg','thumb_link':'http:\/\/photos4.meetupstatic.com\/photos\/member\/7\/3\/d\/8\/thumb_246269656.jpeg'},'guests':0,'member':{'member_id':187433278,'name':'Mae Jackson'},'rsvp_id':1553923885,'mtime':1433211423000,'event':{'name':'repeating test','id':'zzfsglytmbjc','time':1443319200000,'event_url':'http:\/\/www.meetup.com\/Meetup-API-Testing\/events\/222086589\/'},'group':{'join_mode':'open','created':1440671866161,'group_lon':-73.98999786376953,'id':1556336,'urlname':'Meetup-API-Testing','group_lat':40.70000076293945}},{'created':1429943773000,'response':'yes','guests':0,'member':{'member_id':184911456,'name':'Vincent'},'rsvp_id':1547870043,'mtime':1429943773000,'event':{'name':'repeating test','id':'zzfsglytmbjc','time':1443319200000,'event_url':'http:\/\/www.meetup.com\/Meetup-API-Testing\/events\/222086589\/'},'group':{'join_mode':'open','created':1440671866161,'group_lon':-73.98999786376953,'id':1556336,'urlname':'Meetup-API-Testing','group_lat':40.70000076293945}},{'created':1440014438000,'response':'yes','member_photo':{'highres_link':'http:\/\/photos2.meetupstatic.com\/photos\/member\/7\/d\/6\/d\/highres_246092109.jpeg','photo_id':246092109,'photo_link':'http:\/\/photos4.meetupstatic.com\/photos\/member\/7\/d\/6\/d\/member_246092109.jpeg','thumb_link':'http:\/\/photos4.meetupstatic.com\/photos\/member\/7\/d\/6\/d\/thumb_246092109.jpeg'},'guests':0,'member':{'member_id':115840832,'name':'Siddharth Kothari'},'rsvp_id':1566343302,'mtime':1440014438000,'event':{'name':'repeating test','id':'zzfsglytmbjc','time':1443319200000,'event_url':'http:\/\/www.meetup.com\/Meetup-API-Testing\/events\/222086589\/'},'group':{'join_mode':'open','created':1440671866161,'group_lon':-73.98999786376953,'id':1556336,'urlname':'Meetup-API-Testing','group_lat':40.70000076293945}},{'created':1439859581000,'response':'yes','member_photo':{'highres_link':'http:\/\/photos2.meetupstatic.com\/photos\/member\/7\/1\/1\/c\/highres_248848956.jpeg','photo_id':248848956,'photo_link':'http:\/\/photos2.meetupstatic.com\/photos\/member\/7\/1\/1\/c\/member_248848956.jpeg','thumb_link':'http:\/\/photos2.meetupstatic.com\/photos\/member\/7\/1\/1\/c\/thumb_248848956.jpeg'},'guests':0,'member':{'member_id':191371016,'name':'Pres Elect Ms. Diane M Chisesi'},'rsvp_id':1566043028,'mtime':1439859581000,'event':{'name':'repeating test','id':'zzfsglytmbjc','time':1443319200000,'event_url':'http:\/\/www.meetup.com\/Meetup-API-Testing\/events\/222086589\/'},'group':{'join_mode':'open','created':1440671866161,'group_lon':-73.98999786376953,'id':1556336,'urlname':'Meetup-API-Testing','group_lat':40.70000076293945}},{'created':1440074692000,'response':'yes','member_photo':{'highres_link':'http:\/\/photos2.meetupstatic.com\/photos\/member\/a\/1\/2\/a\/highres_248981258.jpeg','photo_id':248981258,'photo_link':'http:\/\/photos4.meetupstatic.com\/photos\/member\/a\/1\/2\/a\/member_248981258.jpeg','thumb_link':'http:\/\/photos4.meetupstatic.com\/photos\/member\/a\/1\/2\/a\/thumb_248981258.jpeg'},'guests':0,'member':{'member_id':191571342,'name':'Eduardo Guerra Silva'},'rsvp_id':1566449366,'mtime':1440074692000,'event':{'name':'repeating test','id':'zzfsglytmbjc','time':1443319200000,'event_url':'http:\/\/www.meetup.com\/Meetup-API-Testing\/events\/222086589\/'},'group':{'join_mode':'open','created':1440671866161,'group_lon':-73.98999786376953,'id':1556336,'urlname':'Meetup-API-Testing','group_lat':40.70000076293945}}],'meta':{'next':'','method':'RSVPs v2','total_count':8,'link':'https:\/\/api.meetup.com\/2\/rsvps','count':8,'description':'Query for Event RSVPs by event','lon':'','title':'Meetup RSVPs v2','url':'https:\/\/api.meetup.com\/2\/rsvps?offset=0&format=json&sig=d4e8beb3c5194e923978e613a6f9ef3574ffe1ab&event_id=222086589&page=200&fields=&sig_id=35497602&order=event&desc=false','id':'','updated':1440074692000,'lat':''}}";

        public MainPage()
        {
            this.InitializeComponent();

            var data = JObject.Parse(getData()).GetValue("results") as JArray;
            createGrid(data);
            renderMembers(data);
        }

        private string getData()
        {
            using (var bob = new System.Net.Http.HttpClient())
            {
                return bob.GetStringAsync("http://api.meetup.com/2/rsvps?event_id=224710777&sign=true&key=7e736a3b64d11163344365a29694d21").Result;
            }
        }

        private void createGrid(JArray data)
        {
            var length = data.Count;
            var squareSize = Math.Ceiling(Math.Sqrt(length));

            for (int i = 0; i < squareSize; i++)
            {
                this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                this.mainGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void renderMembers(JArray data)
        {
            var attendees = data.Where(t => t.Value<string>("response") != "no");

            var squareSize = Math.Ceiling(Math.Sqrt(data.Count));
            for (var i = 0; i < attendees.Count(); i++)
            {
                var attendee = attendees.ElementAt(i);

                var link = "http://img2.meetupstatic.com/img/458386242735519287330/noPhoto_50.png";
                if (attendee["member_photo"] != null)
                {
                    link = attendee["member_photo"]["thumb_link"].Value<string>();
                }

                Image img = new Image();
                img.Source = new BitmapImage(new Uri(link));
                Grid.SetRow(img, (int)(i / squareSize));
                Grid.SetColumn(img, (int)(i % squareSize));
                this.mainGrid.Children.Add(img);
            }
        }
    }
}
