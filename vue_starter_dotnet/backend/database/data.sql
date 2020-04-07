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
  (name,brewer,userID,username)
VALUES
  ('Great Lakes Brewing Company', 'Mike', 3, 'Mike');

COMMIT TRANSACTION;
