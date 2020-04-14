"<template>
<div class="base">
  <div class="brewery">
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
  font-weight: bolder;
  background-color: whitesmoke;
  border-radius: 35%;
  width: 40%;
  margin-left: 30%;
  margin-right: 15%;
  padding: 20px;
  padding-bottom: 75px;
  text-align: center;
  overflow-y:auto;
  padding: 50px;
}
.form{
  margin: auto;
}
.base{
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
  background-image: url('../assets/3.jpg');
  overflow-y:auto;
}
img{
  width: 20%;
}
button{
  border: 1px solid black;
  border-radius: 12px;
  
}
</style>