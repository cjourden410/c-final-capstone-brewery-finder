<template>
  <div class="base">
    <div class="beerList">
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
    "beer-list": BeerList
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
  background-color: whitesmoke;
  border-radius: 35%;
  width: 40%;
  margin-left: 30%;
  margin-right: 15%;
  padding: 20px;
  padding-bottom: 50px;
  text-align: center;
}
.beer {
  margin: auto;
}
.base {
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  position: fixed; 
  top: 1; 
  left: 0;
  background-attachment: fixed;
  min-width: 100%;
  min-height: 100%;
  background-image: url("../assets/4.jpg");
}
</style>