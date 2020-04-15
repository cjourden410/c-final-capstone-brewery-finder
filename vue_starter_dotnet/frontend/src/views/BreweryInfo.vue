"<template>
<div class="base">
  <div class="brewery mx-auto">
    <h1>{{brewery.name}}</h1>

    <img v-bind:src="`${brewery.images}`" />
    <table class="form">
      <tr>
        <td style="font-weight: bold">Name</td>
        <td>{{brewery.name}}</td>
      </tr>
            <tr>
        <td style="font-weight: bold">Address</td>
        <td>{{brewery.address}}</td>
      </tr>
            <tr>
        <td style="font-weight: bold">Contact Info</td>
        <td>{{brewery.contactInfo}}</td>
      </tr>
            <tr>
        <td style="font-weight: bold">Hours of Opperation</td>
        <td>{{brewery.hours}}</td>
      </tr>
     
    </table>
    <router-link tag="button" :to="{name: 'beerList', params: {id:brewery.id}}">{{brewery.name}} Beer List</router-link>

  </div>
</div>
</template>

<script>
// import auth from "@/auth.js";

export default {
  name: "brewery",
  props: {
    id: Number
  },
  data(){
    return{
      brewery: {
        id: 0,
        name: "",
        contact: "",
        daysHours: "",
        picture: "",
        address: ""
      },
      user: Object
    }
  },
 methods: {
    getBrewery(id) {
      // This is the url...
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries/${id}`;

      // fetch here...
      fetch(url)
        .then(responce => {
          responce.json()
            .then(json => {
              this.brewery = json;
            })
        }).catch(err => {console.log(err)});
    }
  },
  created() {
      this.getBrewery(this.$route.params.id);
      this.user = this.$attrs.user;
  }
}
</script>

<style scoped>
.brewery {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 1000px;
  min-height: 600px;
}
.base {
  align-items: center;
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
  background-image: url("../assets/13.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
.form{
  margin: auto;
}
img{
  width: 20%;
}
button{
  border: 1px solid black;
  border-radius: 12px;
  margin: 3px;
  background-color: gainsboro;
}
</style>