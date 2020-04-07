import Vue from 'vue'
import Router from 'vue-router'
import auth from './auth'
import Home from './views/Home.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'
import AddBeer from './views/AddBeer.vue'
import DeleteBeer from './views/DeleteBeer.vue'
import BeerInfo from './views/BeerInfo.vue'
import BeerReview from './views/BeerReview.vue'
import AddBrewery from './views/AddBrewery.vue'
import BreweryInfo from './views/BreweryInfo.vue'
import BreweryInfoUpdate from './views/BreweryInfoUpdate.vue'
import BreweryList from './views/BreweryList.vue'
import RatingsAndReviews from './views/RatingsAndReviews.vue'

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
      path: "/addBeer",
      name: "addBeer",
      component: AddBeer,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/deleteBeer",
      name: "deleteBeer",
      component: DeleteBeer,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/beerInfo",
      name: "beerInfo",
      component: BeerInfo,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/beerReview",
      name: "beerReview",
      component: BeerReview,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/addBrewery",
      name: "addBrewery",
      component: AddBrewery,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/breweryInfo",
      name: "breweryInfo",
      component: BreweryInfo,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/breweryInfoUpdate",
      name: "breweryInfoUpdate",
      component: BreweryInfoUpdate,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/breweryList",
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
      path: "/ratingsAndReviews",
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

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && !user) {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
