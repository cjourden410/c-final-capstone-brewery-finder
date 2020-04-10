  <template v-if="user.rol==='Admin'">
  <div class="base">
  <div class="BreweryAdd">
    <h1>Add Brewery</h1>
    <div>Welcome {{user.sub}}, {{user.rol}}</div>
    <form>
      <!-- <div>
        Name of Brewery:
        <input type="text" name="Brewery" v-model="Brewery" class="breweryInput" placeholder="Billy Bob's Shine Factory" />
      </div>
      <div>
        Name of Head Brewer:
        <input type="text" class="breweryInput" placeholder="Billy Bob" />
      </div>
      <div>
        User ID:
        <input type = "number" class="breweryInput" placeholder="123" />
      </div>
      <div>
        Username:
        <input type="text" class="breweryInput" placeholder="BillyBob123" />
      </div> -->
      <div>
        Name of Brewery:
        <input type="text" v-model="brewery.name" class="breweryInput" placeholder="Billy Bob's Shine Factory" />
      </div>
      <div>
        Name of Head Brewer:
        <input type="text" v-model="brewery.brewer" class="breweryInput" placeholder="Billy Bob" />
      </div>
      <div>
        User ID:
        <input type = "number" v-model.number="brewery.userID" class="breweryInput" placeholder="123" min="1"/>
      </div>
    
      <!-- <button type="submit" @click.stop.prevent="submit()">Submit</button> -->
      <button v-on:click="register">Submit</button>
    </form>
  </div>
  </div>
</template>

<script>
import auth from "@/auth.js";

export default {
  name: "breweryAdd",
  props: {},
  data() {
    return {
      brewery: {
        breweryID: 0,
        nameOfBrewery: "",
        HeadBrewer: "",
        UserID: 0,
        Username: ""
      },
      registrationErrors: false
    };
  },
   created() {
    this.user = auth.getUser();
  },
  methods: {
    
    // submit() {
    //   //if you want to send any data into server before redirection then you can do it here

    //   this.$router.push("/BreweryList");
    // },
    // register() {
    //   fetch(`${process.env.VUE_APP_REMOTE_API}/breweryadd`, {
    //     method: "POST",
    //     headers: {
    //       Accept: "application/json",
    //       "Content-Type": "application/json"
    //     },
    //     body: JSON.stringify(this.brewery)
    //   })
    //     .then(response => {
    //       if (response.ok) {
    //         this.$router.push({
    //           path: "/breweryAdd",
    //           query: { registration: "success" }
    //         });
    //       } else {
    //         this.registrationErrors = true;
    //       }
    //     })

    //     .then(err => console.error(err));
    // }
        register() {
     // Use fetch to Add the brewery on the server (POST)

      let url = `${process.env.VUE_APP_REMOTE_API}/breweries`;

      // fetch here...
      fetch(url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.brewery)
      }).then( response => {
        if(response.ok){
          response.json().then(json => {
            this.brewery = json;
            alert(`Brewery with id ${this.brewery.id} was added!`)

            // Redirect to the breweryList page
            this.$router.push("/BreweryList");
          });
        }
        else {
          alert(`There was an error: ${response.status}: ${response.statusText}`);
        }
      });
    }
  },
};

</script>

<style scoped>
.BreweryAdd {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding: 10px;
  padding-bottom: 20px;
  text-align: center;
}
.breweryInput {
  width: auto;
}
form{
  -webkit-box-align: start;
}
.base{
  width: auto;
  height: 600px;
  background-image: url('../assets/6.jpg');
}
</style>