<template>
  <div class="base">
    <div class="beerList mx-auto">
      <h1>Beer List</h1>
      <!-- <div>Welcome {{user.sub}}, {{user.rol}}</div> -->

      <beer-list :beers="beers" class="beer"></beer-list>
    </div>
  </div>
</template>

<script>
import BeerList from "@/components/BeersList.vue";
import auth from "@/auth.js";

export default {
  name: "beers",
  components: {
    "beer-list": BeerList,
  },

  data() {
    return {
      beers: []
    };
  },
  methods: {
    GetBeers(breweryID) {
      let url = `${process.env.VUE_APP_REMOTE_API}/beers?breweryID=${breweryID}`;

      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.beers = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  created() {
    this.GetBeers(this.$route.params.id);
    this.user = auth.getUser();
  }
};
</script>

<style scoped>
.beerList {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 1000px;
}
.base {
  align-items: center;
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  /* position: fixed; */
  top: 1;
  left: 0;
  /* background-attachment: fixed; */
  min-width: 100%;
  min-height: 100%;
  background-image: url("../assets/10.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
.beer {
  margin: auto;
}
</style>