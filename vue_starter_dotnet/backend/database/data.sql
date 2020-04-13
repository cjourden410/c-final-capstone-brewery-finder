-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('user', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'User');

-- default username of 'admin' and default password of 'password'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('admin', '+LzIkKQWvUXKHIp+oTB77lJu9V0=', 'Ce1wvvfHcpg=', 'Admin');

-- default username of 'Mike' and default password of 'password'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('Mike', 'INZ+8Cfe3TLRO5lM2skBfWr7Wkc=', 'K5ZEctZBc+g=', 'Brewer');

-- default username of 'Chris' and default password of 'password'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('Chris', '0kilsGIOPQswmXJc/ZgNfaoytq8=', 'ZdtiSGQJw40=', 'Brewer');

-- default username of 'Andrew' and default password of 'password'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('Andrew', 'RWFOvW9/Qptuufnz8gs1vRt+CwA=', 'NRI9jbtf3jo=', 'Brewer');

-- default username of 'Fred' and default password of 'password'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('Fred', 'rOaJg4ohJrqXWyyVv+d6pGB8BO4=', '+zDfw30D45M=', 'Brewer');

-- adding brewery to breweries table
INSERT INTO breweries
  (name,brewer,userID,hours,contactInfo,address,history,images)
VALUES
  ('Great Lakes Brewing Company', 'Mike', 3, 'Mon - Sat: 11:30AM - 8:30PM', '216-771-4404', '2516 Market Ave. Cleveland Ohio 44113', 'Two Irish brothers with limited brewing experience. A city that shuttered its last production brewery in the early 80s. A neighborhood in serious need of a facelift. In 1986 when Patrick and Daniel Conway opened their fledgling operation in Cleveland''s Ohio City neighborhood, the odds were stacked against them. Fortunately, they surrounded themselves with a staff of passionate, knowledgeable people, and from the start committed themselves to bringing a sophisticated, diverse selection of craft beer to their home state. Two decades, multiple awards, and a whole lot of stories later, Pat and Dan Conway celebrate over two decades of brewing exceptional beer for their adventurous and discerning customers.', 'https://www.greatlakesbrewing.com/sites/default/files/glbc-logo-white-1000x358_0.png');

INSERT INTO breweries
  (name,brewer,userID,hours,contactInfo,address,history,images)
VALUES
  ('Thirsty Dog Brewing Company', 'Chris', 4, 'Mon - Thurs: 12:00PM - 9:00PM, Fri - Sat: 12:00PM - 10:00PM, Sun: 12:00PM - 5:00PM', '234-571-1456', '587 Grant St. Akron, Ohio 44311', 'Here at the Thirsty Dog Brewing Company, full flavor, delicate balance, texture and aroma combine to make beer an infinitely complex and thoroughly enjoyable experience.

Each of our beers is meticulously hand crafted in small batches using the finest ingredients. High quality malted barley is the source of the beer''s sweetness and body. Select American and European hops are used to balance the malt sweetness, and at times to add special flavors and aromas to the beer.

Our carefully selected ingredients, along with our specially designed recipes and brewing processes, give Thirsty Dog beers unique flavor profiles that are hard to find in today''s mass-market “one size fits all” society.

Our craft brewed beers are far more diverse in range and character than the small spectrum of mass-market beers offered to the American public by the large national breweries.', 'https://thirstydog.com/wp-content/uploads/logo-1.png');

INSERT INTO breweries
  (name,brewer,userID,hours,contactInfo,address,history,images)
VALUES
  ('Hoppin'' Frog Brewing Company', 'Andrew', 5, 'Mon - Thurs: 11:00AM - 6:00PM, Fri - Sat: 11:00AM - 7:00PM', '330-352-4578', '1680 East Waterloo Rd. Akron, OH 44306', 'Hoppin'' Frog is an artisanal brewery in Akron, Ohio making very flavorful beers in the most flavorful styles.  Established in 2006 and brewing with an uncompromising focus on detail from the ingredient selection to the brewing process, the Brewery has become known for quality around the world, and now distributes in 22 states and 38 foreign countries. Hoppin'' Frog has now been rated 20th Best Brewer In The World by RateBeer, the world''s largest and most comprehensive beer-rating website, and thus are One Of The 100 Top Brewers In The World, now for 13 years in-a-row! Hoppin'' Frog is the concept of owner and established brewmaster Fred Karm, a brewer since 1994 who has designed and produced 23 award winning beers at the Great American Beer Festival and World Beer Cup - the two most prestigious contests in the world.', 'https://untappd.akamaized.net/site/brewery_logos_hd/brewery-673_65618_hd.jpeg');

-- adding beers into beers table Great Lakes ID 1
INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Dortmunder Gold', 'A classic award-winning balance of sweet malt and dry hop flavors, proudly waving the flag for Cleveland and refreshing beer drinkers everywhere since 1988.', 'https://www.greatlakesbrewing.com/sites/default/files/styles/large/public/dort-2020-fixed.png?itok=dDcB5nJS', 5.8, 'Lager', 1);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Eliot Ness', 'Admittedly, it’s a bit of a paradox to name our Amber Lager for history’s most famous agent of prohibition. But it’s a smooth, malty (and dare we say, arresting?) paradox.', 'https://www.greatlakesbrewing.com/sites/default/files/styles/large/public/eliotness-fixed_1.png?itok=k-GSENtB', 6.1, 'Lager', 1);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Holy Moses White Ale', 'Refreshment or bust! Orange peel, coriander, and chamomile stake their claim in this unfiltered White Ale, named for our fair city''s founder, Moses Cleaveland.', 'https://www.greatlakesbrewing.com/sites/default/files/styles/large/public/eliotness-fixed_2020.png?itok=nGi1apTh', 5.4, 'Witbier', 1);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Burning River Pale Ale', 'A toast to the Cuyahoga River Fire! For rekindling an appreciation of the Great Lakes region''s natural resources (like the malt and hops illuminating this fresh Pale Ale).', 'https://www.greatlakesbrewing.com/sites/default/files/styles/large/public/burning-river-combo-2018-290x480.png?itok=EOCDhtVI', 6.0, 'Pale Ale', 1);

  INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Commodore Perry IPA', 'What''s this? A British-style IPA named after the man who defeated His Majesty''s Royal Navy in the War of 1812? Consider this a bold, hoppy (and mildly ironic) plunder of war.', 'https://www.greatlakesbrewing.com/sites/default/files/styles/large/public/commodore-fixed_1.png?itok=s17Bfb8k', 7.7, 'IPA', 1);

-- Thirsty Dog ID 2
INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Labrador Lager', 'A traditional German Dortmunder Style Lager. Golden in color, easy drinking, and nicely balanced.', 'https://thirstydog.com/wp-content/uploads/LabLager-2.jpg', 5.3, 'Lager', 2);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Siberian Night', 'Very dark, rich, creamy and full-bodied with a complex character from generous amounts of roasted, toasted, and caramel malts.', 'https://thirstydog.com/wp-content/uploads/siberian.jpg', 8.9, 'Stout', 2);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Old Leghumper', 'This dark brown, robust porter is full bodied with a deep roasted, silky smooth, malty sweet taste.', 'https://thirstydog.com/wp-content/uploads/LegHumper.jpg', 5.9, 'Porter', 2);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Citra Dog', 'You''ll find evidence of tangerine, grapefruit, orange and mango in the flavor and aroma from the multiple addition of a single hop variety, Citra.', 'https://thirstydog.com/wp-content/uploads/new-beer-page-image-CITRA2.jpg', 6.8, 'IPA', 2);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Blood Hound Orange IPA', 'Infused with blood oranges and hopped with Azacca & Centennial hops for a refreshing, fruit flavored sensation.', 'https://thirstydog.com/wp-content/uploads/BLOODHOUND.jpg', 5.3, 'IPA', 2);

-- Hoppin Frog ID 3
INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Turbo Shandy Citrus Ale', 'Born from European tradition, our shandy is a refreshing combination of lemon and light malt flavors. Unlike traditional shandy''s, Turbo Shandy revs it up a couple notches with a high test, full flavored approach as only Hoppin'' Frog can do!', 'http://ampl.client.hoppin-frog.site-store.s3.amazonaws.com/images/ba/bbe90cf957403ba23ae0435c8e581f.jpg', 7.0, 'Shandy', 3);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('B.O.R.I.S The Crusher Imperial Oatmeal Stout', 'This Bodacious Oatmeal Russian Imperial Stout will crush you like no other! This is the grand-daddy of all stout styles, with an intensely deep roasted and full bodied flavor. A robust hop character adds a refreshing balance', 'http://ampl.client.hoppin-frog.site-store.s3.amazonaws.com/images/fa/2f2994f442419daa64cdb56db7e20a.jpg', 9.4, 'Stout', 3);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Gangster Frog IPA', 'Crisp and satisfying American I.P.A. with a skillfully assertive American hop aroma & flavor. Bright spicy citrus hop character up front, with a distinct orange & tropical fruit hop bouquet to add a welcome complexity & strike the perfect balance. It''s all about the hops with Gangster Frog I.P.A.', 'http://ampl.client.hoppin-frog.site-store.s3.amazonaws.com/images/b9/97d775181a4d6a9427da3f22333adc.jpg', 7.5, 'IPA', 3);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Barrel Aged D.O.R.I.S. The Destroyer Double Oatmeal Imperial Stout', 'Aged in Bourbon whiskey barrels to add a wonderful complexity to our massive American Double Imperial Stout. This barrel aging imparts a memorable buttery, vanilla-like, and savory whiskey character, making this one of our most complex beers we''ve ever brewed. Another testament to our hard work and dedication in bringing our customers the very best.', 'http://ampl.client.hoppin-frog.site-store.s3.amazonaws.com/images/ba/74eebbfd5544668f72e18e476d7c51.jpg', 10.5, 'Stout', 3);

INSERT INTO beers
  (name,description,image,abv,beerType,breweryID)
VALUES
  ('Infusion A: Peanut Butter Chocolate Coffee Porter', 'Swirls of heavenly chocolate and peanut butter flavors surround your senses as you enjoy this wonderful maze of complexity that is "Infusion A." This robust coffee porter is a great example of the eye-opening flavors we have developed.', 'http://ampl.client.hoppin-frog.site-store.s3.amazonaws.com/images/2c/38715852a3439a926bbea201904f56.jpg', 6.2, 'Porter', 3);

-- adding reviews into beer review table
INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Amazing beer, one of my favorites!', 1, 5);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Helping me get through the daily grind!', 2, 4);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Solid white ale. Even better with a fresh orange slice!', 3, 4);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Alright, alright, alright!', 4, 4);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Getting me through this quarantine, one bottle at a time!', 5, 5);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Really solid lager with a lot of flavor!', 6, 5);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Dark creamy and right up my alley.', 7, 4);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Haha, leghumper.', 8, 4);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Alright, alright, alright!', 9, 4);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('When paired with a hot summer day and an orange wedge, it doesn''t get better than this.', 10, 5);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('You haven''t had a shandy until you''ve had this. Amazing!!!', 11, 5);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('One of the better oatmeal stouts I''ve had. Really happy that these come in bomber bottles!', 12, 4);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Not bad. Has an aroma that I can''t place.', 13, 3);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('I''m such a sucker for whiskey barrel. The base packs some serious dark chocolate.', 14, 4);

  INSERT INTO beerReviews
  (review,beerID,rating)
VALUES
  ('Peanut butter and chocolate, but alcoholic...what''s not to love?', 15, 5);

COMMIT TRANSACTION;
