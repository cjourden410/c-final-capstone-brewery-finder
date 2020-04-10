<template>
      <div>Welcome {{user.sub}}, {{user.rol}}</div>

</template>

<script>
import auth from "@/auth.js";

export default {
created() {
    this.user = auth.getUser();
  }
}
</script>

<style scoped>

</style>