import Vue from 'vue'
import Router from 'vue-router'
import auth from './auth'
import Home from './views/Home.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'
import BreweryList from './views/BreweryList.vue'

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
      component: Register,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/deleteBeer",
      name: "deleteBeer",
      component: Register,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/beerInfo",
      name: "beerInfo",
      component: Register,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/beerReview",
      name: "beerReview",
      component: Register,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/addBrewery",
      name: "addBrewery",
      component: Register,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/breweryInfo",
      name: "breweryInfo",
      component: Register,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/breweryInfoUpdate",
      name: "breweryInfoUpdate",
      component: Register,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/breweryList",
      name: "breweryList",
      component: Register,
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
      component: Register,
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
    },
    {
      path: "/BreweryList",
      name: "breweryList",
      component: BreweryList,
      meta: {
        requiresAuth: true
      }
    },
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
