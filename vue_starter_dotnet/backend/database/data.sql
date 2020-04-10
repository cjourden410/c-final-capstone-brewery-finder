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

-- adding brewery to breweries table
  INSERT INTO breweries
  (name,brewer,userID,hours,contactInfo,address,history,images)
VALUES
  ('Great Lakes Brewing Company', 'Mike', 3, 'Mon - Sat: 11:30AM - 8:30PM', '216-771-4404', '2516 Market Ave. Cleveland Ohio 44113', 'Two Irish brothers with limited brewing experience. A city that shuttered its last production brewery in the early 80s. A neighborhood in serious need of a facelift. In 1986 when Patrick and Daniel Conway opened their fledgling operation in Cleveland''s Ohio City neighborhood, the odds were stacked against them. Fortunately, they surrounded themselves with a staff of passionate, knowledgeable people, and from the start committed themselves to bringing a sophisticated, diverse selection of craft beer to their home state. Two decades, multiple awards, and a whole lot of stories later, Pat and Dan Conway celebrate over two decades of brewing exceptional beer for their adventurous and discerning customers.', 'https://www.greatlakesbrewing.com/sites/default/files/glbc-logo-white-1000x358_0.png');

-- adding beers into beers table
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

COMMIT TRANSACTION;
