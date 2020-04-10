import Vue from 'vue'
import Router from 'vue-router'
import auth from './auth'
import Home from './views/Home.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'
import BeerAdd from './views/BeerAdd.vue'
import BeerDelete from './views/BeerDelete.vue'
import BeerInfo from './views/BeerInfo.vue'
import BreweryAdd from './views/BreweryAdd.vue'
import BreweryInfo from './views/BreweryInfo.vue'
import BreweryInfoUpdate from './views/BreweryInfoUpdate.vue'
import BreweryList from './views/BreweryList.vue'
import RatingsAndReviews from './views/RatingsAndReviews.vue'
import BeerList from './views/BeerList.vue'
import AccountUpdate from './views/AccountUpdate.vue'
import ViewRatings from './views/ViewRatings.vue'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/accountUpdate",
      name: "accountUpdate",
      component: AccountUpdate,
      meta: {
        requiresAuth: true,
        isBrewer: true,
        isAdmin: true   
      }
    },
    {
      path: "/breweries/beerList/:id",
      name: "beerList",
      component: BeerList,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/breweries/beerAdd",
      name: "beerAdd",
      component: BeerAdd,
      meta: {
        requiresAuth: true,
        isBrewer: true,
        isAdmin: true
      }
    },
    {
      path: "/breweries/deleteBeer/:id",
      name: "deleteBeer",
      component: BeerDelete,
      meta: {
        requiresAuth: true,
        isBrewer: true,
        isAdmin: true
      }
    },
    {
      path: "/breweries/beerInfo/:id",
      name: "beerInfo",
      component: BeerInfo,
      meta: {
        requiresAuth: true
      }
    },
  
    {
      path: "/breweries/breweryAdd",
      name: "breweryAdd",
      component: BreweryAdd,
      meta: {
        requiresAuth: true,
        isAdmin: true
      }
    },
    {
    path: "/breweries/viewRatings",
      name: "viewRatings",
      component: ViewRatings,
      meta: {
        requiresAuth: true,
      }
    },
    {
      path: "/breweries/breweryInfo/:id",
      name: "breweryInfo",
      component: BreweryInfo,
      meta: {
        requiresAuth: true
      }
    },

    {
      path: "/breweries/breweryInfoUpdate/",
      name: "breweryInfoUpdate",
      component: BreweryInfoUpdate,
      meta: {
        requiresAuth: true,
        isBrewer: true,
        isAdmin: true
      }
    },
    {
      path: "/breweries",
      name: "breweryList",
      component: BreweryList,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/breweries/ratingsAndReviews/:id",
      name: "ratingsAndReviews",
      component: RatingsAndReviews,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const user = auth.getUser();
  const isAdmin = to.matched.some(x => x.meta.isAdmin);
  const isBrewer = to.matched.some(x => x.meta.isBrewer);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && !user) {
    next("/login");
  }else if (isAdmin && user.rol !=='Admin')
  {
    auth.logout();
    next("/login");
  }else if ((1 === 0 && user.rol !=='Admin') && (isBrewer && user.rol !== 'Brewer'))
  {
    auth.logout();
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
  
});

export default router;
