using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Location
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(new List<Location>()
                    {
                        new Location()
                        {
                            Name = "Anaheim Convention Center",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.tsnn.com%2Fsites%2Fdefault%2Ffiles%2FAnaheim%2520Convention%2520Center.jpg&f=1&nofb=1&ipt=ef16d511d4d8e5b0dba7997be54d7e408c3ec1e2ef9ec25d748ba8526dc24df0&ipo=images",
                            Description = "Located in the fabulous city of Anaheim, home to the world famous Disneyland, the Anaheim Convention Center is perfect for all ocasions of entertainment. "




                        },
                        new Location()
                        {
                            Name = "Los Angeles Convention Center",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.incollect.com%2Fsites%2Fuploads%2FLos_Angeles_Convention_Center_wikicommons.JPG&f=1&nofb=1&ipt=78455be9d7595a27a8dbc5766c5321ee9124f4710d6ccc04b69f994646ee9a13&ipo=images",
                            Description = "Located in the diverse, famous, and populous city of Los Angeles, the Los Angeles Convention Center is perfect for all ocasions of entertainment. "
                        },
                        new Location()
                        {
                            Name = "Venetian Convention and Expo Center",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2F3blaws.s3.amazonaws.com%2Fimages%2FSands_Expo_Venetian_Palazzo-web.jpg&f=1&nofb=1&ipt=21c75e72f3b37fbb592016f6c652cd4fdb3d255866002a7d57ecf5270469635e&ipo=images",
                            Description = "This is the description of the first Location"
                        },
                        new Location()
                        {
                            Name = "Austin Convention Center",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Logo = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Faustin.towers.net%2Fwp-content%2Fuploads%2Fsites%2F19%2Flg_5.jpg&f=1&nofb=1&ipt=2076aeb42fb92cc8a661e4b3b2e37cf288a0742451d8dd652741af2817b3c6f8&ipo=images",
                            Description = "This is the description of the first Location"
                        },
                        new Location()
                        {
                            Name = "Dolby Theater",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Logo = "https://upload.wikimedia.org/wikipedia/commons/f/f5/Dolby_Theatre_logo.svg",
                            Description = "Located in the famous Hollywood District of Los Angeles, CA, this is the best place for music artists and live perforamnces to be held in for world recognition. "
                        },
                         new Location()
                        {
                            Name = "DeVos Place Convention Center",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQeai8Gf_VM9LTucZKcgV34NLi34r21zQOQQ&usqp=CAU",
                            Description = "Located in scenic Grand Rapids, Michigan, this is a perfect place to host a wide range of events for the people of Michigan!"
                        },
                    });
                    context.SaveChanges();
                }
                //Participants
                if (!context.Participants.Any())
                {
                    context.Participants.AddRange(new List<Participant>()
                    {
                        new Participant()
                        {
                            FullName = "Beyoncé",
                            Bio = "Beyoncé Giselle Knowles-Carter is an American singer, songwriter, and actress",
                            ProfilePictureURL = "https://s1.r29static.com/bin/entry/ebe/x,80/2238977/image.jpg"

                        },
                        new Participant()
                        {
                            FullName = "Aniplex",
                            Bio = "Aniplex Inc. (株式会社アニプレックス, Kabushiki-gaisha Anipurekkusu) is a Japanese anime and music production company owned by Sony Music Entertainment Japan.",
                            ProfilePictureURL = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxMHBhUQBxMVFRUVGBgWFxcWFRgfGxcYGR0aGBUdGRgYISggHRomIxkXITIiJSktLi4vGh8zODMtNygtLisBCgoKDg0OGxAQGjElHyYrLS0tLy0tLS0tLS8tLS01LS0tKy0tLS0tLS0tLS0tLS8tLS0tLS0tLS0tLS0tLS0tLf/AABEIAMkA+wMBEQACEQEDEQH/xAAcAAEAAgMBAQEAAAAAAAAAAAAABQYDBAcBAgj/xABKEAACAQMCAwIHCQ0GBwAAAAAAAQIDBBEFBhIhMQdBEyJRYXGBkRQWMlNzobGy0RUjJDM1NkJSdJOzwcIlN0NigvEIJzRjcoOS/8QAGQEBAAMBAQAAAAAAAAAAAAAAAAECAwQF/8QAMhEBAAIBAQUGBAUFAQAAAAAAAAECAxEEMTNRcRITITKRwUFCcoEURGGCsSM0Q1KhIv/aAAwDAQACEQMRAD8A4aAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGxYWc7+6VO2XFKXRZX0sTK+Olr27NY8Xt9ZVLGtwXcJQku5r6PKRE6l8dqTpaNJaxKgBM6LZQubC5lWWXTpKUefR5wZZLTE16uzZsdb0yTaN0eHqhjVxgH3CPE8LqBvXWj1rO0jVuqcoxk8Jvv9XVEaw2tgyUrFrR4I99SWLwAAAAAAAAAAAAAAAAAkqOhXFekpUqUmnzT5fzZrGG8xroPv3u3XxMvm+0t+HycjU97t18TL5vtH4fJ/qMN3pdaxp8V3TcU3hN4xn1espfFenjMCZubays7Sgr2nW4qlGFRzpyXWWf0ZejuK+DpmMdYiJjfGrB9yrO4X4Jd8Pmqwa+dDSPgr3eOd1vV5Lateos2TpVl/wBupFv2PBHZJwW+Hj0NoQdLc0I1FhrjTT7mk8lLbmmxRpnh7Q3HOCdLUoxr0stcNTqlz+DPqh2U12q0f+bx2o/X2ll+49vqvPQqvDN/4NZpP/TLoxrMb1u4xZfHFPjyn2lXrmhK2uJQrrhlFtNPuaLOO1ZrOk703tz8l3vyK+sjDL5q9XdsfDzfT7oBLmbvPTmnaA61qq+oVI0aL6Sk+csfqx7yvadWLZta9u89mv8APRnes0NKWNAp5l316qzL/RHpH2DszO9f8RjxcGPHnPj6R8H3eXU7zaHHdScpOu+bf+URGlk3va+za2nWe0j9P2/X1GgqlCKUOa45SSjy69efzFtHNTFa3i2vuBSt/wDr7yivLGHjv1Y5E6L91WPNaP5eRWn28v8AHrP1QX2k+CP6Mc5Ydc0vwO4p2+mxbw1wxzl/BUnzfrEVmZ0hXNWKXmsMXvdus/iZfN9pp3GTkyPe7dfEy+b7R+HycjUW3br4mXzfaO4ychH3NCVtVcK6cZLqmZTWazpIxEAAAAAAAD0kTu4a0qfgFCTX3mPRteU3zTPhpyQi6EqtetGFFzlKTUYpN5bbwkvOYdqUuw1ex33FtSdxqF3V8PToyqShHHCpJOSjl8/Nn0jtSOXubqbTbm2/wiPVv9SXlN9dcP3Qybo/F2n7LT/qMLOjP8v0w6honYjSvdBpVb64qxrVKSqOEVDCbSaXNZ71n0kMFF7NdrPX97RoNuMaLlUnJLp4N+KvJzlj1ZELVt2bRbkyTtaVl2m1Kenzc4RqVFxPHOWHxdO5PK9RW7q2Sdc8TP6qvp9jLU9ahb2/wqtVU16ZSwWclt8rlv8A2dQ2Xr9pQsq06s5tTqcajiK44xhjHlxPr5ERK2Lzx1VTdEHU3NWUFluo0l5W+hFdzbbOPbq6zLs5s9taXT+6t1Ug7mmlcNuGIRSTnKHi5SUnFc8/CM8vmr1bbHw8v0+8IHtF7MKO3duxv9EuZVaTcE1PheYz+DKE44TXTljo855GzgUzX/yNZfJS+sVrvl2bTw8fRZdwdn9LQez2lqN9WqKvW8GoUsR4cz8bDeM8oJv2FnGrcvzJXy7+qV+Z2flf3PjVee2bP/3/AFoF53Qyvw6/dfNudl1pcbOpX+5byVsqvNZ4FFRbfg+cl1aWSGDS3Hs7RtL0WpW03VPD1YrxKUZU25yzhLxeePOBDXH94k/RL+CdGDi+v8Ntq4kqzZVlK8gr2pUjTc4qbi22oNrjaXlxkw7U82LofaT2by2tSt3o1avX8PN08PrxY4oJcPXPjewdqRh3DsqltLbcKm47ur7tqpuFtSkml5OOT54X6TXfyWepMWnmKbux/wBtz9EfoRrtHnlEIYwSAAAAAAA97iRNblXjUPkYfzNs3w6IdM7G9nO1s5a1qNGdRwjJ2tGK8acsNcaT6+SOeX6XcmsErhocryvsHU625qc6VarOvNQn3U/A0owUf8q4WvUwOAx/NF/tEfqM3/w/dHxWbSNB98m6dNtpJuDoUpVOv4uLlKeWumUuHPlaMZdGf5fph2Gz3L7s7Zp2dN+JRtJwx3eEc6dSXsSx/sQwRmy9KjtGy1O9uOUqlzUo0m+/E3Thjyp1JP2MmN61I1tETzhxzRue+5fKVf6il3Zs39z6rX2D6H7v3nO6rLxLVSafd4SeYx9OFxP2FnFbfKtb1133w9oc68HmPhowp/8AhCSjHp3PDfrC2Lzx1TGztE+7va/wTWYU6sq0/NGnzWfTJwj6ytdzba+Pbq6Nvuvpup65J6hdOSpw8BcUo5+9U1KU5SWF8JycYvHcl5DPL5q9W2x693l+n3hzftQ7QIbktqVjoUHTtKPC1lYc3FOMOXdGKbwu/PPojZwNPS9Ee4r/AEq1XSonx+anGXFUf/yn68Fa75dm08PH091i/wCITWVca7RsrdpQt4ZaXRTnjC9UYr2+cs41Ely2Svl39Ur8zs/K/ubtnpUtbs9NtaOc1alaHLuTnDifqWX6i8/BjfhU+7s/aNdaPSt6Om7kq1KcaMYyhTo8WFFLghnCfJJPCIYuJb2hp1PUqcdnOrKlw5nKo3lzbfJZSwkse0Dcuf7xZ+iX8E6MHF9f4bbTxJVfTdOq6rfRoadCVSpN4jGK5t/yXe2+SXNnOxfq6FOrp2zIqsqVxd2dHKXJpVo02o470+FtZ5NqT8oH5X1jV62u6rK51SbqVJtZb7l3JLuiuiSEDNuz8ty9EfoRttHnkQ5iAAAAAAAPe4kW5U7aprdp74ZyhQVKDnwxbcks+Ksc+fTPpNs/y9ELHvTtZr1dTjT2dUdva0oRhBKEczwlzcZLxUvgpebz4WCUlt7tUhV2NdW+6a9Spc1PCxpvwfLglTioLMUkvG4/aBzSP5pP9oj9Rm/+H7odJ2Nuay2nWhc6y5eFdlRhSjGDfLMnLxl0y1FGUujP8v0wqWwd2R0rtAWoa03ibqyqOMW+dRPOEu7LKsF53/2jW243aWu33JxdzTnVzBxXKaaXPq23kmN6+Lz16w53ov59y+Uq/wBRXI69m/ufVbdsb3tdsdndzb2cp+7azqdISwnJ8EXx9PFjmXp5EuK2+XM9N/KNL5SH0oiVsfnr1dV2jvKz2ZquoVL9VJXFSbjBRimuGKylxN8syfzIiu5ttfHt1UXR7mV5a39W4eZTpuUn55TyzPL5q9W2x8PL9PurcWbOB17s83FZbXjb3OvSkpe55Qp8MJS6zzPOPRErXfLr2nh4+nu29W1fa+salO41BXEqlR8Upff1l9OieO5Is5HPtWnTqbbnLT4uFJ3U3Ti224wx4qbfNvGOpX5nZ+V/ctXZ3rlpt2Npda9KSUIXKp8MHLMpSpp5x0ws+0vO6GN+HT7pvXdd2zr2qTudUVxOpPHE/vyXJKKwk8JYSIYuSa7O3qa5UeiRcKHH97Um2+Hl1cuee8CwXC/5iT9Ev4J0YOL6/wANtq4krBtzdun7E23OW327i/qrDqTpuMKef1c8+BeTrJ9cLkudiydk/aPS0Kd2t01JyVeUailwuTc8ONTix5VwewDnOtSpT1yq9Nk5UnVk6bccNwcsx5d3XoBn3Z+W5+iP0I32jzyiEMYJAAAAAAAAJinuKrCjGMo0pcKSTlTTeF05m8Z7aaexo+vfHU+LofukT388o9EaHvjqfF0P3SHfzyj0NGC+1ipf23g6qhGKfFiEUsvDSz7WUvltaNPZOiZvqFvqFpbzr3UKfBQhBx4XKXFHOeS6dSm91WitorM2+ENT+z7f4+t7IIeCn9GOc/8AHsdfpWk09NtKUWmmpTzNprmnz6P0Eap76seWsQbTqu43TGdXrJzk/S02yl9zTY5mc8TP6tay0KtqVSUqUeGCbzUn4sIrnz4n19ROqlNmvkmZiPDnPhDejVs9FlmgvdVVc+J5VKLXkXWRHjLWJwYfL/6n0hAX13K8vJ1a2OKbcnhcsvyLyExGjkveb2m075TG3PyXe/Ir6yMsvmr1dux8PN9PugIvDNnnp+y1ilXsoUNapccIZUKkOU4JvPrRXTk7MeelqxTLGsRumN8Pa+3PD0nU0OauIdXFcqkfTDq/UO1zLbJ2o7WKe1H/AH0fVWLhszE1hq4eU1z+D5BHmTMabLpP+zWsdddvZxo3VGlVpx4uFTj40eLnLEl09hfVhXLpERMaxDP7rsLj8db1KTffTnlL1S5jWExbFO+NOgtNs7iX4Jd8L8lam1865E+B3eOd1vU13U/BbqqXGnyjLmsPqn4ijL0rqia3mtu1CueYtkmYYPfHU+Lofuka9/blHox0PfHU+LofukO/nlHoaJ2hSurlQdmrSpxKm8Rg1wqpJwi5cUVhJp5fRJZ6YI7+3KPROipalczu7uU7nHE3h46cuXIyvabTrI1SoAAAAAAAAAAAAAAAANzSr+WmX8a1DDce6XRkTGrTFlnHeLQzatrNbVH+FT8XuguUV6IoRGi2XaL5fNP2+COySxeATug140tOu1Ukk5UUo5fV5XJGOSJma9Xdslorjy6z8vugjZwvcgZbWvK2qqdCTjJdGnhhatprOsTolNS3DW1SxjSvOF4fFxKOJN4x42CsViNzfJtN8tYrZDPqWc2rwAB7kDwABu0dSrW/4mpKPiuHJ/ovOY+jm+XnA1JvieX3gfIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP//Z"
                        },
                        new Participant()
                        {
                            FullName = "Bethesda Softworks",
                            Bio = "Bethesda Softworks LLC is an American video game publisher based in Rockville, Maryland.",
                            ProfilePictureURL = "https://elder-geek.com/wp-content/uploads/2010/03/bethesda.jpg"
                        },
                        new Participant()
                        {
                            FullName = "Crunchyroll",
                            Bio = "Crunchyroll is an American subscription video on-demand over-the-top streaming service that specializes in the distribution, production and licensing of Japanese anime and dorama.",
                            ProfilePictureURL = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAkFBMVEXzdSL////ybADyawDzcRXyaQDzchnzcx3yZwDzcRjzbgjzbw75xKj2mWXybgDzeiX718j3rof71sL2pnn+8+z+9/L4vKD0ik70gTb6ybH0hkP/+/n+9O797eT84NH4t5b2nWz4s4/2oXP1k1v85djzfC/1j1T5xqz6z7n3qYD0gz/2n3D1lmD96N784tT+8OQ86ZYcAAANYUlEQVR4nO1d65qqOgzF0ou2413xgoqgOOiMc97/7Q4tKi0XBUeB2V/Xnz1bRbtIm6RpEgxDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0OjeSAYQw6MSd1DeTUIpAC1e/6s+zU+jr+6M7/XRoDCf4MoZmZv5lmDs92SYZ8HljfrmQzXPcDfoQPgwdmo3BSeG2fGQKfuYT4LDGA3WOWyu2IVdCH4i5Jk7UMwfUgvwjSYtWHdAy4HQtlwXZBehPWQ0b+jeAg1rKLikwRpGbTukRcEw1a+brkH28Gs7sEXAG4Py8vvJsdhu+k6h5iHcusvifXBrJvDXUC8+BU/jk/YYPsIDo/N32NMDqBuIjkgyHoBPw4HNdJwdMjmRQRbrQ1u4Exly+dVaBqrZePsBugWG7q9Hiys4djbbr2x+xFsJnkf7DbM/KNjAXY/H96yhwBgDMJOB0JGgYnw4RhkGphxo8wGch+xW392Ecrc82IIEB6P0m6Qi6onkgfTuU9v+jmj9K6zAsOd1ihFsTFSBMO7/PYeLrL/65i+kzCnw4YYRjC+x2+wQ0W3foSBsap5xo2gyL7v8NvMUClXGrY9heN3A4wGPuXzW3fN0lsF2HPlrzjVvtcgLNeitRz6VGiC+pLOmbC6HTgzpQFvAjw9u4gI8mLbMapZoQI3j6D1G++ZwdjHdWvVNniWw8/u/m5cBMUmdlnnUgQ5G/q1/2sdaN5s0LrGeQpyNoQbeO+2YwZCUMoo7fE/co4v6OG6GJ3a5inJMRRB/hLEFOGuG2z+i7Za9mQ/sI4nBLI0Juxf1fS8Ln0Ksre8i7xZxcP8n1nz2h4MTyhNEl8pbmoSItzmSDD746y3uxfm37t+ynvF/oXitp6Yfy9TzYyyCVL6OMw/mpkJOWI/uifrWoTIMje9P5ljgT2nUBh8v0xQ7PjRdcc6/FOQFTmcZB1gY3NcLIaz6aauhjvxzqoGIcJMEWY5ymBZLAg3+TYzImyXzeex+pWIspaVl55MsndyF4scP90M+LvrykMaOGtXGLRTn4N4UIxgflQGCIW6q9p3AxkDn6QlSA8Fo6hevmsWOb+jilci8TNGuUtNM5BtMjMkeM/3NIVz6Ffr2LCMxbVI3eX7ERwJeV7CBZTPU6dag2GeU6O0UyMw3YIEJw8UJeQB9XOluoYs08McJhmCInFwgYdOmclXfdIbeCsyJukkeYtZwZOM0JN5qETELqbSaYp+UsMcJ+SAM8T8rAjD+RAaxZ8qpylOjTLpGxOaH4NLYJq2oimQefjBCt0a+JUaZtKryo/BpZDWwRlA4fdtqzs2pR/JUa4SBOn9owwFXhHZ4NADt6o7UgSpZfih/jjpl8gZKhajCP3g7J3ZW4BSo0w4HKj4HG21ioXS2LBlV6Zq0i7bjzrKzq4EwYK7BhLuhStz3KCXHGXC2ueFUTOxLyiZ0OoXWrGvAEuFSfvKzU3fgVcwhOPqbD4I7g+ylAgL722JUcyuvAJmUpVayr3tFN0yRbCLBu3B+aeq+H4qjKjuv1HJ3Kii+oN+rHvvoJMBmHDIbIWgcLDK4Kug/sDbaWV+WyIyoS7DrM3xXXwWdVVY6w1cspAyhwtliJlBuHso4nlH3/xfRQYxxVDxukm/JMFwGRf0qMGgokOoFMODvA5hCZ/7gqJHS+zjVBHDpCpR7mzKWL5OiHBYUSAjKcOV8rP0iUz2gkdLuFuVDBMMFSsVeh5P4OOuX0P6l3+X/htpKT+obv6UMB8+PMOw5d2xGHh+Xaj9t/KSQFR7OJDnGCuvaAQOuRQxnkyrPrNg6lJTThTSAY6C2OYdjvuryiP6oQusjC2QGT6jSiNYWVl+BG35kqg0GMxZqDEKhaH5fEnCfpk8xifUiGpwDhVP08RMVBii9IFGcQRzKeeEQHArgqswjijAXGVcyjos7ZWq2A+XCPGUKbPdH8dTpbLwxQUJi6DoUvN3DEPY+1EQjDaKvk4eGbwdVBnSWd55/1KGOahahoapbIHXL1uHuah6HSaU6UpWdL/QpXdQeZpCwnGR7fHz9vAeqraHBlFTg2fS7z/t09xF1T5NuNpyNV3CkrwGk+rzoNW5KIeScJkji6I4V5/Vph6RysfPz+0PH6CyWLcEZQNly9bqmT3+I6TSPCqAai9kxxiUOTosiIqCFwrUxD35TOiJWNsjTGvJEFZSLZSFWD5e+ghVJ+1dGCpniESaRq/3TCv3uwUIkccgR71Ln1s8RE01iIpJlKPWeXUmT6OeSZokIh9zlz0/fITvuiq7TFmIjuTW5FSaPIt6ai04lAxMJQE6u9TkWdSQpX+FKfeikXfhsGhqcBFkJI9XBmJI0X3FOS6XjHEf4zqruakrjUROEoWFk2cf4lxvGbCc7a2kxaCCRRaPMau3Wl3JA5anU2axwjNY1N39Qy6TncrHiGXyS+9gReqqHr0B7OPhfCiR4ZdsotI1KpWDzCV9Kq8ZQl7Q9qu+EmcJcs2B4n108kr1i2NT9yKMYEpLUTmOp7913mo2FDHkjOeubJ4fNOZ5hLVRu5a5ohdrG1tJpX3UXOkuVvPa+7bcQHDspK17CsXnpTjpN4cgP62NgzYDZfGY6dKTYtj3GjNFBXA/lqLqhdDvpzrxjRpGMKRoxB6qmt8E/Sd2/MOmaFEJBMa5358KxfIdMSfLhjUUjEBQHNQI1KwRsNzf4ZOCVa47WIWQOguOgEIRg2PhMqjBvAmeWg5ArFX2if6jzCjWHnrfTSYNNQvQuGmV1UwVBaHEeahVBzvUwMasCkg7NvFuotEQYe1uRoPLG9ZWv3z7uhpA/Vv8YtNPqsQOwNtFVpBq+uOcwF9pOk/A19XBsYfplpcdAOZda7Sf2kKctj3ZLIYHw6y9s14ZSN129qmmQSFIhwETsb4/n/sEIADuNgZrJmjvpjmDeZ5yJBzVjuuVoNC9ztVg2VgL/jswtr2ajsGO/hUtUg4QnZzz1RL4f/6ROZkgDPnuIFqSe2eGAPv3HvTEWwOzpTtac5r2xunOexT+ezRDlqA/67qL0ea83wTu17KyypAKQUIrSAEwTfAvylBDQ0NDQ0NDQ+OPgUD47ANkr1fyp+1G//ADoaaBnIbHZ/sihFfuCE+UPx632Jg77tCg6cbKdaPDEzeeytoW+fG8Nqfdiko6l5a1GG4ad0j1S4YfEsO+M9y6Vv0JRQm8kKHvuD76+JcZvgEQoB5AQAyPUIBQj0fPMGOXAUMmommEAWT2egjFAUQcXtYTD3gQDL02QpfvMdjtciYu51eHXxz9CDNRD13i/e9nSKg3mtr2ZHTkZJbWYG3brSEEQcuO0pR5xskIGMRwNxM7xP7Dv4wdfAfhK6uB6xPBMBisp+uRF46cHFr2pZq/F/51NknfHZ2ntihugH1rH37Pj2PAKhiS/u2g+oBv/dhChqNWayoYwlVUGCEVCx3EYSC7nX4PYUdKgjvPsUh5F/27RJc+h/Yv2X4/psG214OBKX+q1dsZStn3B3xrKujKDCecoZLDLsYuZWGqDHmKuiiv4eUUouDNvyX77U3lET2hBX03QzGSlXs4HYabGREMg+1s6RsphvyENBjvduJhFqFOiThZu9PsOBpHDH9cb+xwUVtMjJuXT+JQYAMkyovPx8NyTkTxlIMRsQThtzNs89nTp5hgBkjUGHIp4teZDPsMY8qfSxFaaNGc/tsMr+TPT480jQkh5Y+OWAPx9tSMXv+CgqGDMCFChJ/tUHZtPslP5M0MRdZ2XKkqGEb125kMRWOs3kS0BAG23IMothaiagpE1bY7zP83xVGJuOjBKCaNqNsUhY4uezNDzAcWl64UYgjE/xP3JmZIeTVKzzAQFzVgK/GpmCGnHOU5isZin/TNDMXDOrynGPJk/rjBcZoh/QwXeHt3UScxw9G1ulg0pQrAuxl6LdkVKcPw9IChIHX6jGpuEgwjU88X9OLdMhTdWtxb+q/MkC8nQYAXdwcphgYf2OjOLBWdQpx1VEocM+Sijb4neu3dDEOPo9XaRP0bicJQaIQZI4RFg0sxRBOuLCNpkCyGvMUGt+3QkBmKdSG6foonEm0772YoGpYM2wAAtJzLDEUHhUnX97sToRRTDEWbjAXvGoT8JclgeGn+JhJvY4airf0aACqUkE3fbg+jVhDrIBitrz7NpduHXGq4ZkaKYVSPsRotgv3Vp1EZXur3PVWG0Z2ZLizxlC/r/Qzl6h+VodxQaYbTDA0W94XOZijuni3+lBjK6fHcD3//3gJcn0llL4nM0ICni+M5OoUjh+6N4fSiYujuKuavTmxYaXBlKJlMmSG5tYGx+HupKMbrAdHOtazhDIVm6/S9+771aCTAXHa/lyaI7PPusItePux2UcwJo5lrfTjdcEtI5mNvLFpAkIPnjcXbgsmlnsgPv/jWIYKCreu4XXCxNWPPO/BIlOd57yp9Dje70SbXIBirvZHx7eA6fkt+kVF6ufIWTSQiHBgCTqUCVIzlI3B8/UHxOTWa+Hcg9lt19C6pDCjUKHZz6n9eD7FNCt4TWWoG2MdqMq251vfNILI20dDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NBoNP4H2fDWsAlrwuwAAAAASUVORK5CYII="
                        },
                        new Participant()
                        {
                            FullName = "Adele",
                            Bio = "Adele is an English singer and songwriter.",
                            ProfilePictureURL = "https://cloudfront-us-east-2.images.arcpublishing.com/reuters/XWPYJKS5VFLDNGWRW2FVOBXE3E.jpg"
                        },
                        new Participant()
                        {
                            FullName = "Activision Blizzard",
                            Bio = "Activision Blizzard, Inc. is an American video game holding company based in Santa Monica, California.",
                            ProfilePictureURL = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.tvqc.com%2Fwp-content%2Fuploads%2F2015%2F11%2Factivision-blizzard.jpg&f=1&nofb=1&ipt=f86c309f40fa127da7724a81bf92a0b70edd142ab6939774869980fd968dd6fc&ipo=images"
                        },
                        new Participant()
                        {
                            FullName = "Sam Worthington",
                            Bio = "Samuel Henry John Worthington[1] (born 2 August 1976) is an Australian actor. He is best known for playing Jake Sully in Avatar, Marcus Wright in Terminator Salvation, and Perseus in Clash of the Titans and its sequel Wrath of the Titans.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6c/Sam_Worthington_2013.jpg/220px-Sam_Worthington_2013.jpg"
                        },
                        new Participant()
                        {
                            FullName = "Zoe Saldana",
                            Bio = "Zoë Yadira Saldaña-Perego (née Saldaña Nazario; born June 19, 1978) is an American actress.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0f/Zoe_Saldana_by_Gage_Skidmore_2.jpg/220px-Zoe_Saldana_by_Gage_Skidmore_2.jpg"
                        },
                        new Participant()
                        {
                            FullName = "Sigourney Weaver",
                            Bio = "Susan Alexandra (Sigourney) Weaver (/sɪˈɡɔːrni/;[1] born October 8, 1949) is an American actress.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Sigourney_Weaver_by_Gage_Skidmore_4.jpg/220px-Sigourney_Weaver_by_Gage_Skidmore_4.jpg"
                        },
                        new Participant()
                        {
                            FullName = "Kryptek",
                            Bio = "A well known hunting equipment company based in the United States, specializing in camoflage gear.",
                            ProfilePictureURL = "https://kryptek.com/themes/kryptek/assets/images/kryptek.png"
                        }
                    });
                    context.SaveChanges();
                }
                //Sponsors
                if (!context.Sponsors.Any())
                {
                    context.Sponsors.AddRange(new List<Sponsor>()
                    {
                        new Sponsor()
                        {
                            FullName = "Parkwood Entertainment",
                            Bio = "Based in Los Angeles, California and founded in 2010. This is the record label of Beyoncé.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/PWE.svg/260px-PWE.svg.png"

                        },
                        new Sponsor()
                        {
                            FullName = "SColumbia Records",
                            Bio = "This is Adele's official record label.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Columbia_Records_Colored_Logo.svg/180px-Columbia_Records_Colored_Logo.svg.png"
                        },
                        new Sponsor()
                        {
                            FullName = "Square Enix",
                            Bio = " 	Square Enix Holdings Co., Ltd. is a Japanese entertainment conglomerate and video game company.",
                            ProfilePictureURL = "https://cdn.vox-cdn.com/thumbor/nPxlQDBMFHnmxMJuyNzYi0fETu0=/0x0:1100x619/1200x800/filters:focal(462x222:638x398)/cdn.vox-cdn.com/uploads/chorus_image/image/52626247/square_enix.0.jpg"
                        },
                        new Sponsor()
                        {
                            FullName = "Berkley",
                            Bio = " 	Berkley is a well-known fishing equipment company in the United States.",
                            ProfilePictureURL = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fi.ebayimg.com%2Fimages%2Fg%2FJDYAAOSw--1Ws8Me%2Fs-l500.jpg&f=1&nofb=1&ipt=5473e07989a412ac1a723e029d7a7b877cb894f227c165fd65b5b4f5384e912c&ipo=images"
                        },
                        new Sponsor()
                        {
                            FullName = "20th Century Studios",
                            Bio = "An American film production studio located in Los Angeles, CA.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/en/thumb/5/5e/20th_Century_Studios.svg/347px-20th_Century_Studios.svg.png?20220126141643"
                        }
                    });
                    context.SaveChanges();
                }
                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Name = "Beyoncé Performance",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Description = "Live in Austin, Texas, we have the one and only Beyoncé performing in the Austin Convention Center. Purchase your tickets now!",
                            Price = 50.50,
                            ImageURL = "https://media.npr.org/assets/img/2013/12/29/175480175-6be58ea344fd42c77b80c953f512aaefbef53ecc-s1100-c50.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            LocationId = 3,
                            SponsorId = 1,
                            EventCategory = EventCategory.Film
                        },
                        new Event()
                        {
                            Name = "Anime Expo 2023",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Description = "Come and join us in the widely popular Anime Expo! Explore a variety of Japanese activities and upcoming anime booths from your favorite studios! Purchase tickets now!",
                            Price = 99.50,
                            ImageURL = "https://a-to-jconnections.com/uploads/3/4/8/6/34864225/anime-expo-main-logo-2021_orig.png",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            LocationId = 1,
                            SponsorId = 3,
                            EventCategory = EventCategory.Film
                        },
                        new Event()
                        {
                            Name = "Adele Performance",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Description = "The Grammy Award winning Adele performing live in Austin, Texas in the Austin Convention Center! Don't miss this popular music artist's live performance that is sure to make your night! Purchase your tickets now!",
                            Price = 199.50,
                            ImageURL = "https://static01.nyt.com/images/2016/03/02/arts/music/02adele-web/02adele-web-superJumbo.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            LocationId = 4,
                            SponsorId = 2,
                            EventCategory = EventCategory.Film
                        },
                        new Event()
                        {
                            Name = "E3 2023",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Description = "The popular technology and video gaming venue comes back to Los Angeles Convention Center in Los Angeles, California. Come and explore the latest popular and upcoming games and technology of 2023 and beyond! Purchase your tickets now!",
                            Price = 149.50,
                            ImageURL = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fgameranx.com%2Fwp-content%2Fuploads%2F2022%2F09%2FE3-2023.jpg&f=1&nofb=1&ipt=7d0d919789588175c4652bc4b54932ef691fdff6a4b2192abaa29bf4560fc234&ipo=images",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            LocationId = 1,
                            SponsorId = 2,
                            EventCategory = EventCategory.Film
                        },
                        new Event()
                        {
                            Name = "Ultimate Sport Show",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Description = "Michigan’s finest tradition for the avid fisherman, hunter or outdoor loving family! Exhibitors will be at the show with the latest in outdoor gear, travel information and fishing boats. The features are famous: Antique Lures, Trout Pond, Hawg Trough, Woodcarvers, and the Rock Wall. Nearly 100 fishing and hunting seminars will be held on 5 stages, including “Lake Ultimate,” the 110,000 gallon indoor lake.",
                            Price = 29.50,
                            ImageURL = "https://s1.ticketm.net/dam/a/b49/73dd5d26-600a-4ea5-9e3d-7c3aa7ec4b49_556981_TABLET_LANDSCAPE_LARGE_16_9.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            LocationId = 1,
                            SponsorId = 3,
                            EventCategory = EventCategory.Film
                        },
                        new Event()
                        {
                            Name = "Avatar: The Way of Water",
                            AddressLine = "800 W Katella Ave",
                            City = "Anaheim",
                            State = "CA",
                            ZipCode = "92802",
                            Country = "United States",
                            Description = "The long awaited sequel to the 2009 Avatar film has arrived! Reserve your tickets now, playing at the famous Dolby Theater.",
                            Price = 20.00,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMWFmYmRiYzMtMTQ4YS00NjA5LTliYTgtMmM3OTc4OGY3MTFkXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            LocationId = 1,
                            SponsorId = 5,
                            EventCategory = EventCategory.Film
                        }
                    });
                    context.SaveChanges();
                }
                //Participants & Events
                if (!context.Participants_Events.Any())
                {
                    context.Participants_Events.AddRange(new List<Participant_Event>()
                    {
                        new Participant_Event()
                        {
                            ParticipantId = 1,
                            EventId = 1
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 3,
                            EventId = 1
                        },

                         new Participant_Event()
                        {
                            ParticipantId = 1,
                            EventId = 2
                        },
                         new Participant_Event()
                        {
                            ParticipantId = 4,
                            EventId = 2
                        },

                        new Participant_Event()
                        {
                            ParticipantId = 1,
                            EventId = 3
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 2,
                            EventId = 3
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 5,
                            EventId = 3
                        },


                        new Participant_Event()
                        {
                            ParticipantId = 2,
                            EventId = 4
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 3,
                            EventId = 4
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 4,
                            EventId = 4
                        },


                        new Participant_Event()
                        {
                            ParticipantId = 2,
                            EventId = 5
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 3,
                            EventId = 5
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 4,
                            EventId = 5
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 5,
                            EventId = 5
                        },


                        new Participant_Event()
                        {
                            ParticipantId = 3,
                            EventId = 6
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 4,
                            EventId = 6
                        },
                        new Participant_Event()
                        {
                            ParticipantId = 5,
                            EventId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
