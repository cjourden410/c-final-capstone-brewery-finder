<template>
  <div class="base">
    <div class="delete">
      <h1>Remove {{beer.name}} from your Beer List</h1>
      <button v-on:click="deleteBeer">Delete Beer</button>
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
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding: 10px;
  padding-bottom: 20px;
  text-align: center;
}
</style>