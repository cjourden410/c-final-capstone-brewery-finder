<template>
  <div class="base">
    <div class="beer">
      <h1>{{beer.name}}</h1>
      <img v-bind:src="`${beer.image}`" />\
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
          <td>{{beer.avgRating}}</td>
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
  font-weight: bolder;
  background-color: whitesmoke;
  border-radius: 35%;
  width: 40%;
  margin-left: 30%;
  margin-right: 15%;
  padding: 20px;
  padding-bottom: 50px;
  text-align: center;
  overflow-y:auto;
  padding: 50px;
}
.form {
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
  background-image: url("../assets/5.jpg");
  overflow-y:auto;
  padding: 50px;
}
img {
  width: 25%;
}
button{
  border: 1px solid black;
  border-radius: 12px;
  
}
</style>