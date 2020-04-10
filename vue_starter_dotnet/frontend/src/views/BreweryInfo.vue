<template>
<div class="base">
  <div class="brewery">
    <h1>{{brewery.name}}</h1>
    <h1>Details</h1>
    <!-- <div>Welcome {{user.sub}}, {{user.rol}}</div> -->

    <table class="form">
      <tr>
        <td>Name</td>
        <td>{{brewery.name}}</td>
      </tr>
            <tr>
        <td>Address</td>
        <td>{{brewery.address}}</td>
      </tr>
            <tr>
        <td>Contact Info</td>
        <td>{{brewery.contactInfo}}</td>
      </tr>
            <tr>
        <td>Hours of Opperation</td>
        <td>{{brewery.hours}}</td>
      </tr>
      <tr>
        <td><router-link tag="button" :to="{name: 'beerList', params: {id:brewery.id}}">{{brewery.name}} Beer List</router-link></td>
      </tr>
    </table>
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
      }
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
  }
}
</script>

<style scoped>
.brewery {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding: 10px;
  padding-bottom: 20px;
  text-align: center;
}
.form{
  margin: auto;
}
.base{
  width: auto;
  height: 600px;
  background-image: url('../assets/3.jpg');
}
</style>