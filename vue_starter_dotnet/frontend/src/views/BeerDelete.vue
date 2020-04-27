<template>
  <div class="base">
    <div class="delete mx-auto">
      <h1>Remove {{beer.name}} from your Beer List</h1>
      <button v-on:click.prevent="deleteBeer">Delete Beer</button>
      <router-link tag="button" class="navibar" :to="{name: 'home'}">Cancel and return to Home</router-link>
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
        name: ""
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
    },
    deleteBeer() {
      let url = `${process.env.VUE_APP_REMOTE_API}/beers/${this.beer.id}`;
      fetch(url, {
        method: "DELETE"
      }).then(response => {
        if (response.ok) {
          alert("Beer has been DELETED!");
          this.$router.push({ name: "breweryList" });
        } else {
          alert(
            `There was an issue Deleting this beer: ${response.status}: ${response.statusText}`
          );
        }
      });
    },
  },
  created() {
      this.getBeer(this.$route.params.id);
      this.user = auth.getUser();
    }
};
</script>

<style scoped>
.delete {
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
  background-image: url("../assets/7.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
button{
  border: 1px solid black;
  border-radius: 12px;
  margin: 3px;
  background-color: gainsboro;
  margin-bottom: 10px;
}
</style>