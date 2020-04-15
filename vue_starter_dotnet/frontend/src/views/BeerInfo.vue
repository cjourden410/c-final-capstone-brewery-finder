<template>
  <div class="base">
    <div class="beer mx-auto">
      <h1>{{beer.name}}</h1>
      <img v-bind:src="`${beer.image}`" v-if="(`${beer.image}` != '')" />
      <p>{{beer.description}}</p>
      <table class="form">
        <tr>
          <td style="font-weight: bold">Beer Type</td>
          <td>{{beer.beerType}}</td>
        </tr>
        <tr>
          <td style="font-weight: bold">Beer ABV</td>
          <td>{{beer.abv}}%</td>
        </tr>
        <tr>
          <td style="font-weight: bold">Beer's Average Rating</td>
          <td><img class="stars" :src="require(`../assets/${beer.avgRating}-star.png`)" /></td>
        </tr>
      </table>
      <router-link
        tag="button"
        :to="{name: 'ratingsAndReviews', params: {id:beer.id}}"
      >Rate: {{beer.name}}</router-link>
      <router-link
        v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')"
        tag="button"
        class="navibar"
        :to="{name: 'deleteBeer'}"
      >Delete Beer</router-link>
    </div>
  </div>
</template>

<script>
import auth from "@/auth.js";

export default {
  name: "beer",
  props: {
    id: Number
  },
  data() {
    return {
      beer: {
        id: 0,
        name: "",
        discription: "",
        beerType: "",
        abv: "",
        avgRating: 0
      }
    };
  },
  methods: {
    getBeer(id) {
      let url = `${process.env.VUE_APP_REMOTE_API}/beers/${id}`;
      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.beer = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  created() {
    this.getBeer(this.$route.params.id);
    this.user = auth.getUser();
  },
  watch: {
    $route: function() {
      this.user = auth.getUser();
    }
  }
};
</script>

<style scoped>
.beer {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 1000px;
  min-height: 710px;
}
.base {
  align-items: center;
  width: 100vw;
  height: .08vh;
  background-size: cover;
  overflow: hidden;
  position: fixed;
  top: 1;
  left: 0;
  background-attachment: fixed;
  min-width: 100%;
  min-height: 100%;
  background-image: url("../assets/13.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
.form {
  margin: auto;
}
img {
  width: 25%;
}
button{
  border: 1px solid black;
  border-radius: 12px;
  margin: 3px;
  background-color: gainsboro;
}
.stars{
  width: 50%
}
</style>